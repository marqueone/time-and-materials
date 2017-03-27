using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "work_orders")]
    public class WorkOrder 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [MaxLength(24)]
        [Required]
        public string WorkOrderId { get; set; }

        public virtual Project Project { get; set; }

        public virtual IList<TimeEntry> TimeEntries { get; set; }

        public virtual IList<MaterialWorkOrder> MaterialWorkOrders { get; set; }
    }
}