using System.Collections.Generic;
using Marqueone.TimeAndMaterials.Api.Entities;

namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType Type { get; set ;}
        public ICollection<ContactMethod> Contacts { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}