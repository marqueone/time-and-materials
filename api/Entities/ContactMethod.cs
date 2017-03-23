using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class ContactMethod 
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public bool IsPrivate { get; set; }
    }
}