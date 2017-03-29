using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class WorkOrder 
    {
        public int Id { get; set; }
        public string WorkOrderId { get; set; }

        public virtual IList<TimeEntry> TimeEntries { get; set; }

        public virtual IList<Material> Materials { get; set; }
    }
}