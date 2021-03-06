using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "companies")]
    public class Company 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        [Column]
        public DateTime DateAdded { get; set; }
    }
}