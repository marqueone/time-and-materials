using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "trades")]
    public class Trade 
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
        public decimal PayRate { get; set; }

        [Column]
        [Required]
        public bool IsActive { get; set; }

        public virtual IList<EmployeeTrade> EmployeeTrades { get; set; }
    }
}