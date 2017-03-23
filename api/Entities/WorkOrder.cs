using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class WorkOrder 
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string WorkOrderId { get; set; }
        public IEnumerable<TimeEntry> TimeEntries { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}