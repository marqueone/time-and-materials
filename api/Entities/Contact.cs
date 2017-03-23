using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ContactMethod> Contacts { get; set; }
        public int CompanyId { get; set; }
    }
}