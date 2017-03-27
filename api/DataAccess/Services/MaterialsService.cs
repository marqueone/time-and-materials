using System.Collections.Generic;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class MaterialService
    {
        private TamContext _context { get; set; }
        private DbSet<Material> Materials => _context.Materials;
        private DbSet<Service> Services => _context.Services;
        private DbSet<Equipment> Equipment => _context.Equipment;


        private ILogger<MaterialService> _logger { get; set; }
        public MaterialService(TamContext context)
        {
            _context = context;
        }

        public async Task<IList<Material>> GetMaterials()
        {
            return await Materials
                            .Include(u => u.UnitOfMeasure)
                            .ToListAsync();
        }
    }
}