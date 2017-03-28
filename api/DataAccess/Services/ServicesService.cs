using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class ServicesService
    {
        private TamContext _context { get; set; }
        private DbSet<Service> Services => _context.Services;

        public ServicesService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Service>> GetServices()
        {
            return await Services.ToListAsync();
        }

        internal async Task<Service> GetById(int id)
        {
            return await Services.SingleAsync(s => s.Id == id);
        }

        internal async Task<IList<Service>> GetByType(RateTypes type)
        {
            return await Services.Where(s => s.RateType == type).ToListAsync();
        }

        internal async Task<bool> Add(string name, RateTypes rateType, decimal rate)
        {
            Services.Add(new Service 
            { 
                Name = name, 
                Rate = rate,
                RateType = rateType
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> Update(int id, string name, decimal rate, RateTypes rateType)
        {
            var service = await Services.SingleOrDefaultAsync(s => s.Id == id);
            
            if(service != null)
            {
                service.Name = name;
                service.Rate = rate;
                service.RateType = rateType;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> Delete(int id)
        {
            var service = await Services.SingleOrDefaultAsync(m => m.Id == id);
            if(service != null)
            {
                Services.Remove(service);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}