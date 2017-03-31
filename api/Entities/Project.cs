using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "projects")]
    public class Project
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
        public ProjectType ProjectType { get; set; }

        [Column]
        [Required]
        public DateTime Start { get; set; }

        [Column]
        public DateTime End { get; set; }

        [Column]
        [Required]
        public DateTime ProjectedEnd { get; set; }

        [Column]
        [Required]
        public bool IsComplete { get; set; }
    }
}