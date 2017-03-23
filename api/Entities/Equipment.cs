using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Abstract;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "equipment")]
    public class Equipment : IConsumable 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Column]
        [Required]
        public RateTypes RateType { get; set; }

        [Column]
        [Required]
        public decimal Rate { get; set; }
    }
}