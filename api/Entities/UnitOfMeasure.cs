using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Models;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "units_of_measure")]
    public class UnitOfMeasure 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Column]
        [Required]
        [MaxLength(16)]
        public string Value { get; set; }

        [Column]
        [Required]
        public UnitType UnitType { get; set; }
    }
}