using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewServiceViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public RateTypes RateType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }

    public class UpdateServiceViewModel 
    {
        [Required]
        public int Id { get; set;}

        [Required]
        public string Name { get; set;}

        [Required]
        public RateTypes RateType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}