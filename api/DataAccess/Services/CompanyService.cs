using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Extentions;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class CompanyService
    {
        private TamContext _context { get; set; }
        
        private DbSet<Company> Companies => _context.Companies;

        public CompanyService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Transform.Company>> GetCompanies()
        {
            return await Companies.Select(c => c.ToCompany()).ToListAsync();
        }

        internal async Task<bool> Add(string name)
        {
            Companies.Add(new Company
            {
                Name = name,
                DateAdded = DateTime.Now
            });

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}