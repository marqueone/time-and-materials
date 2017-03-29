using Marqueone.TimeAndMaterials.Api.Entities;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.Extentions
{
    public static class Transforms
    {
        public static Transform.Trade ToTrade(this Trade input)
        {
            return new Transform.Trade
            {
                Id = input.Id,
                Name = input.Name,
                PayRate = input.PayRate,
                IsActive = input.IsActive
            };
        }
    }
}
