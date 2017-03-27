using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "contacts")]
    public class Contact
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        public IEnumerable<ContactMethod> Contacts { get; set; }
    }
}