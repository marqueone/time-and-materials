using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "employees")]
    public class Employee 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Column]
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }

        [NotMapped]
        public IEnumerable<Trade> Trades { get; set; }
    }
}