using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class UnitOfMeasure 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public UnitType UnitType { get; set; }
    }
}