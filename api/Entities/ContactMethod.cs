using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "contact_methods")]
    public class ContactMethod 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public ContactType Type { get; set; }

        [Column]
        [MaxLength(128)]
        public string Value { get; set; }

        [Column]
        public bool IsPrivate { get; set; }
    }
}