namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Trade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PayRate { get; set; }
        public bool IsActive { get; set; }
    }
}