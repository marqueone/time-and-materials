namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Trade 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PayRate { get; set; }
        public bool IsActive { get; set; }
    }
}