using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}