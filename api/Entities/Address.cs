using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "addresses")]
    public class Address 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string AddressLine1 { get; set; }

        [Column]
        [MaxLength(64)]
        public string AddressLine2 { get; set; }

        [Column]
        [MaxLength(64)]
        public string AddressLine3 { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string City { get; set; }

        [Column]
        [Required]
        [MaxLength(2)]
        public string Province { get; set; }

        [Column]
        [Required]
        [MaxLength(16)]
        public string PostalCode { get; set; }

        [Column]
        [Required]
        public int GMT { get; set; }

        [Column]
        [Required]
        public AddressTypes AddressType { get; set; }
    }
}