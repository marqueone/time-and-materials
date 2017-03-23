using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "work_orders")]
    public class WorkOrder 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        public int ProjectId { get; set; }

        [Column]
        [Required]
        public string WorkOrderId { get; set; }

        [NotMapped]
        public IEnumerable<TimeEntry> TimeEntries { get; set; }

        [NotMapped]
        public IEnumerable<Material> Materials { get; set; }
    }
}