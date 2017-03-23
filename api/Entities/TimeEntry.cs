using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "time_entries")]
    public class TimeEntry
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        public int EmployeeId { get; set; }

        [Column]
        [Required]
        public DateTime Start { get; set; }

        [Column]
        [Required]
        public DateTime End { get; set; }

        [Column]
        [Required]
        public bool IsHoliday { get; set; }

        [Column]
        [Required]
        public bool HasOverTime { get; set; }

        [Column]
        [Required]
        public bool IsWeekEnd { get; set; }
    }
}