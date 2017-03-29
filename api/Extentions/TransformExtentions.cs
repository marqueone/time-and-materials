using Marqueone.TimeAndMaterials.Api.Entities;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.Extentions
{
    public static class Transforms
    {
        public static Transform.Trade ToTrade(this Trade input)
        {
            return new Transform.Trade
            {
                Id = input.Id,
                Name = input.Name,
                PayRate = input.PayRate,
                IsActive = input.IsActive
            };
        }

        public static Transform.Project ToProject(this Project input)
        {
            return new Transform.Project
            {
                Id = input.Id,
                Name = input.Name,
                ProjectType = input.ProjectType,
                Start = input.Start,
                End = input.End,
                ProjectedEnd = input.ProjectedEnd
            };
        }

        public static Transform.WorkOrder ToWorkOrder(this WorkOrder input)
        {
            return new Transform.WorkOrder
            {
                Id = input.Id,
                WorkOrderId = input.WorkOrderId
            };
        }

        public static Transform.TimeEntry ToTimeEntry(this TimeEntry input)
        {
            return new Transform.TimeEntry
            {
                Id = input.Id,
                EmployeeId = input.EmployeeId,
                Start = input.Start,
                End = input.End,
                IsHoliday = input.IsHoliday,
                HasOverTime = input.HasOverTime,
                IsWeekEnd = input.IsWeekEnd
            };
        }
    }
}
