namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}