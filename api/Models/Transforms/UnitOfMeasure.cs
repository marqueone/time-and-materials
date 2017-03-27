namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public UnitType UnitType { get; set; }
    }
}