using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Company 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
    }
}