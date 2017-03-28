using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class AddressService
    {
        private TamContext _context { get; set; }
        private DbSet<Address> Addresses => _context.Addresses;

        public AddressService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Address>> GetAddresses()
        {
            return await Addresses.ToListAsync();
        }

        internal async Task<Address> GetById(int id)
        {
            return await Addresses.SingleAsync(s => s.Id == id);
        }

        internal async Task<IList<Address>> GetByType(AddressType type)
        {
            return await Addresses.Where(s => s.AddressType == type).ToListAsync();
        }

        internal async Task<bool> Add(string addressLine1, string addressLine2, string addressLine3, string city, string postalCode, string province, int gmt, AddressType addressType)
        {
            Addresses.Add(new Address 
            { 
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                AddressLine3 = addressLine3,
                City = city, 
                Province = province,
                PostalCode = postalCode,
                GMT = gmt,
                AddressType = addressType
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> Update(int id, string addressLine1, string addressLine2, string addressLine3, string city, string postalCode, string province, int gmt, AddressType addressType)
        {
            var address = await Addresses.SingleOrDefaultAsync(a => a.Id == id);
            
            if(address != null)
            {
                address.AddressLine1 = addressLine1;
                address.AddressLine2 = addressLine2;
                address.AddressLine3 = addressLine3;
                address.City = city;
                address.Province = province;
                address.PostalCode = postalCode;
                address.GMT = gmt;
                address.AddressType = addressType;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> Delete(int id)
        {
            var address = await Addresses.SingleOrDefaultAsync(m => m.Id == id);
            if(address != null)
            {
                Addresses.Remove(address);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}