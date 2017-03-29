using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class EmployeeService
    {
        private TamContext _context { get; set; }

        private DbSet<Employee> Employees => _context.Employees;
        private DbSet<EmployeeTrade> EmployeeTrades => _context.EmployeeTrades;
        private DbSet<Trade> Trades => _context.Trades;
        private DbSet<ContactMethod> ContactMethods => _context.ContactMethods;

        public EmployeeService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Transform.Employee>> GetEmployees()
        {
            var employees = await Employees
                                    .Include("EmployeeTrades.Employee")
                                    .Include("EmployeeTrades.Trade")
                                    .Include(c => c.Contacts)
                                    .ToListAsync();

            var results = new List<Transform.Employee>();
            foreach(var item in employees)
            {
                results.Add(item.ToTransform());
            }

            return results;
        }

        internal async Task<Transform.Employee> GetById(int id)
        {
            var employee = await Employees
                                    .Include("EmployeeTrades.Employee")
                                    .Include("EmployeeTrades.Trade")
                                    .Include(c => c.Contacts)
                                    .SingleAsync(e => e.Id == id);

            return employee.ToTransform();
        }

        internal async Task<bool> Add(string firstName, string lastName, EmployeeType employeeType, IList<ContactMethod> contacts, IList<Trade> trades)
        {
            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Type = employeeType
            };

            employee.EmployeeTrades = new List<EmployeeTrade>();
            foreach(var trade in trades)
            {
                employee.EmployeeTrades.Add(new EmployeeTrade{TradeId = trade.Id});
            }

            Employees.Add(employee);

            return await _context.SaveChangesAsync() >= 0;
        }

        internal Task Update(int id, string firstName, string lastName, EmployeeType employeeType, ICollection<ContactMethod> contacts, ICollection<Trade> trades)
        {
            throw new NotImplementedException();
        }

        internal Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> AddContactMethod(int employeeId, ContactType contactType, string value, bool isPrivate)
        {
            var employee = await Employees
                                    .Include("EmployeeTrades.Employee")
                                    .Include("EmployeeTrades.Trade")
                                    .Include(c => c.Contacts)
                                    .SingleAsync(e => e.Id == employeeId);

            if(employee.Contacts == null)
            {
                employee.Contacts = new List<ContactMethod>();
            }

            employee.Contacts.Add(new ContactMethod { Type = contactType, Value = value, IsPrivate = isPrivate});
            
            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> UpdateEmployeeContact(int id, ContactType contactType, string value, bool isPrivate)
        {
            var contact = await ContactMethods.SingleOrDefaultAsync(c => c.Id == id);

            if(contact != null)
            {
                contact.Type = contactType;
                contact.Value = value;
                contact.IsPrivate = isPrivate;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> DeleteEmployeeContact(int id)
        {
            var contact = await ContactMethods.SingleOrDefaultAsync(c => c.Id == id);

            if(contact != null)
            {
                ContactMethods.Remove(contact);
                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> AddEmployeeTrade(int employeeId, int tradeId)
        {
            EmployeeTrades.Add(new EmployeeTrade 
            { 
                EmployeeId = employeeId, 
                TradeId = tradeId 
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> RemoveEmployeeTrade(int employeeId, int tradeId)
        {
            var trade = await EmployeeTrades.SingleOrDefaultAsync(et => et.EmployeeId == employeeId && et.TradeId == tradeId);

            if(trade != null)
            {
                EmployeeTrades.Remove(trade);
                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}