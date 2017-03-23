using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
    }
}