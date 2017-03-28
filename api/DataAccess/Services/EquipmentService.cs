using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class EquipmentService
    {
        private TamContext _context { get; set; }
        private DbSet<Equipment> Equipment => _context.Equipment;

        public EquipmentService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Equipment>> GetEquipment()
        {
            return await Equipment.ToListAsync();
        }

        internal async Task<Equipment> GetById(int id)
        {
            return await Equipment.SingleAsync(s => s.Id == id);
        }

        internal async Task<IList<Equipment>> GetByType(RateTypes type)
        {
            return await Equipment.Where(s => s.RateType == type).ToListAsync();
        }

        internal async Task<bool> Add(string name, RateTypes rateType, decimal rate)
        {
            Equipment.Add(new Equipment 
            { 
                Name = name, 
                Rate = rate,
                RateType = rateType
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> Update(int id, string name, decimal rate, RateTypes rateType)
        {
            var equipment = await Equipment.SingleOrDefaultAsync(s => s.Id == id);
            
            if(equipment != null)
            {
                equipment.Name = name;
                equipment.Rate = rate;
                equipment.RateType = rateType;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> Delete(int id)
        {
            var equipment = await Equipment.SingleOrDefaultAsync(m => m.Id == id);
            if(equipment != null)
            {
                Equipment.Remove(equipment);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}