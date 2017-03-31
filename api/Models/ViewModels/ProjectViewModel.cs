using System;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewProjectViewModel 
    {
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ProjectedEnd { get; set; }
        public int CompanyId { get; set; }
    }

    public class UpdateProjectViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ProjectedEnd { get; set; }
        public bool IsComplete { get; set; }
    }

    public class NewWorkOrderViewModel
    {
        public string WorkOrderId { get; set; }
        public int ProjectId { get; set; }
    }

    public class NewTimeEntryViewModel
    {
        public int Id { get; set; }
        public string WorkOrderId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsWeekend { get; set; }
        public bool IsHoliday { get; set; }
        public bool HasOverTime { get; set; }
    }
}