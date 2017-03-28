using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class ContactService
    {
        private TamContext _context { get; set; }
        
        private DbSet<Contact> Contacts => _context.Contacts;
        private DbSet<ContactMethod> ContactMethods => _context.ContactMethods;

        public ContactService(TamContext context)
        {
            _context = context;
        }
    }
}