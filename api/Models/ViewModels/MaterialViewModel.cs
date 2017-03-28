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

    public class NewUnitOfMeasureViewModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public UnitType UnitType { get; set; }
    }

    public class UpdateUnitOfMeasureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Value { get; set; }
        public UnitType UnitType { get; set; }
    }
}