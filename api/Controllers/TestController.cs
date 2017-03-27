using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    public class TestController : Controller
    {
        private ILogger<TestController> _logger { get; set; }
        private TamContext _context { get; set; }
        private DbSet<Employee> Employees => _context.Employees;
        private DbSet<Trade> Trades => _context.Trades;
        private DbSet<EmployeeTrade> EmployeeTrades => _context.EmployeeTrades;

        public TestController(TamContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;

            if(Trades.Count() == 0){
                Trades.Add(new Trade { Name = "Electrician", PayRate = 33, IsActive = true });
                Trades.Add(new Trade { Name = "Carpenter", PayRate = 33, IsActive = true });
                Trades.Add(new Trade { Name = "Plumber", PayRate = 33, IsActive = true });
                _context.SaveChanges();
            }

            if(Employees.Count() == 0)
            {
                Employees.Add(new Employee { FirstName = "Mike", LastName = "Sears" });
                Employees.Add(new Employee { FirstName = "James", LastName = "Bond"});

                _context.SaveChanges();
            }

            if(EmployeeTrades.Count() == 0)
            {
                EmployeeTrades.Add(new EmployeeTrade{ EmployeeId = 1, TradeId = 1 });
                EmployeeTrades.Add(new EmployeeTrade{ EmployeeId = 1, TradeId = 2 });
                EmployeeTrades.Add(new EmployeeTrade{ EmployeeId = 1, TradeId = 3 });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("test")]
        public async Task<ICollection<Employee>> GetEmployes()
        {
            if(_context == null) {
                _logger.LogDebug("derp");
            }

            return await _context.Employees.ToListAsync();
        }

        [HttpGet]
        [Route("test2")]
        public IActionResult GetSingleEmployee()
        {
            var employee = Employees
                .Include(e => e.EmployeeTrades)
                .Single(e => e.Id == 1);

            var result = employee.ConvertToEmployee();
            _logger.LogDebug(Json(result).ToString());
            
            return Json(result);
        }
    }
}