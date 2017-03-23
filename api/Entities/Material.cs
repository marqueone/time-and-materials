using Marqueone.TimeAndMaterials.Api.Entities.Abstract;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Material : IConsumable 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}