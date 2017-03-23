using System;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsHoliday { get; set; }
        public bool HasOverTime { get; set; }
        public bool IsWeekEnd { get; set; }
    }
}