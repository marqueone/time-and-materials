using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Abstract;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "materials")]
    public class Material : IConsumable 
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
        public decimal Cost { get; set; }

        [Column]
        [Required]
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public virtual IList<MaterialWorkOrder> MaterialWorkOrders { get; set; }
    }
}