using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewTradeViewModel
    {
        public string Name { get; set; }
        public decimal PayRate { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateTradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PayRate { get; set; }
        public bool IsActive { get; set; }
    }
}