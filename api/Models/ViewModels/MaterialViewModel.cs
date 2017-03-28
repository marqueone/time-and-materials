using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewMaterialViewModel
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Required]
        public int UnitOfMeasure { get; set; }
    }

    public class UpdateMaterialViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Required]
        public int UnitOfMeasure { get; set; }
    }
}