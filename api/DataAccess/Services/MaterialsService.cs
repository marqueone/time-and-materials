using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

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
            return (from item in await Materials.Include(u => u.UnitOfMeasure).ToListAsync() select item.ToTransform()).ToList();
        }

        internal async Task<Transform.Material> GetById(int id)
        {
            var material = await Materials.Include(u => u.UnitOfMeasure).SingleAsync(m => m.Id == id);
            return material.ToTransform();
        }

        internal async Task<IList<Transform.Material>> GetByType(UnitType type)
        {
            var materials = await Materials.Include(u => u.UnitOfMeasure).ToListAsync();
            return (from item in materials 
                    where item.UnitOfMeasure.UnitType == type 
                    select item.ToTransform()).ToList();
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
            
            if(material != null)
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
            if(material != null)
            {
                Materials.Remove(material);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}