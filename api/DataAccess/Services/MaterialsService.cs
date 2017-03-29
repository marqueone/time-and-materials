using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;
using Marqueone.TimeAndMaterials.Api.Extentions;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class MaterialService
    {
        private TamContext _context { get; set; }
        private DbSet<Material> Materials => _context.Materials;
        private DbSet<UnitOfMeasure> UnitsOfMeasure => _context.UnitsOfMeasure;

        public MaterialService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Transform.Material>> GetMaterials()
        {
            return (from item in await Materials.Include(u => u.UnitOfMeasure).ToListAsync() select item.ToMaterial()).ToList();
        }

        internal async Task<Transform.Material> GetById(int id)
        {
            var material = await Materials.Include(u => u.UnitOfMeasure).SingleAsync(m => m.Id == id);
            return material.ToMaterial();
        }

        internal async Task<IList<Transform.Material>> GetByType(UnitType type)
        {
            var materials = await Materials.Include(u => u.UnitOfMeasure).ToListAsync();
            return (from item in materials
                    where item.UnitOfMeasure.UnitType == type
                    select item.ToMaterial()).ToList();
        }

        internal async Task<int> AddMaterial(string name, decimal cost, int unitOfMeasure)
        {
            Materials.Add(new Material
            {
                Name = name,
                Cost = cost,
                UnitOfMeasure = UnitsOfMeasure.Single(u => u.Id == unitOfMeasure)
            });

            return await _context.SaveChangesAsync();
        }

        internal async Task<bool> UpdateMaterial(int id, string name, decimal cost, int unitOfMeasure)
        {
            var material = await Materials.SingleOrDefaultAsync(m => m.Id == id);

            if (material != null)
            {
                material.Name = name;
                material.Cost = cost;
                material.UnitOfMeasure = UnitsOfMeasure.Single(u => u.Id == unitOfMeasure);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> DeleteMaterial(int id)
        {
            var material = await Materials.SingleOrDefaultAsync(m => m.Id == id);
            if (material != null)
            {
                Materials.Remove(material);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<IList<UnitOfMeasure>> GetUnitsOfMeasure()
        {
            return await UnitsOfMeasure.ToListAsync();
        }

        internal async Task<UnitOfMeasure> GetUnitOfMeasureById(int id)
        {
            return await UnitsOfMeasure.SingleAsync(u => u.Id == id);
        }

        internal async Task<IList<UnitOfMeasure>> GetUnitsOfMeasureByType(UnitType unitType)
        {
            return await UnitsOfMeasure.Where(u => u.UnitType == unitType).ToListAsync();
        }

        internal async Task<bool> AddUnitOfMeasure(string name, string value, UnitType unitType)
        {
            UnitsOfMeasure.Add(new UnitOfMeasure
            {
                Name = name,
                Value = value,
                UnitType = unitType
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> UpdateUnitOfMeasure(int id, string name, string value, UnitType unitType)
        {
            var unit = await UnitsOfMeasure.SingleOrDefaultAsync(u => u.Id == id);

            if (unit != null)
            {
                unit.Name = name;
                unit.Value = value;
                unit.UnitType = unitType;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> DeleteUnitOfMeasure(int id)
        {
            var unit = await UnitsOfMeasure.SingleOrDefaultAsync(u => u.Id == id);
            if (unit != null)
            {
                UnitsOfMeasure.Remove(unit);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}