using Marqueone.TimeAndMaterials.Api.Entities.Abstract;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Service : IConsumable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RateTypes RateType { get; set; }
        public decimal Rate { get; set; }
    }
}