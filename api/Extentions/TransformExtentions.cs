using System.Collections.Generic;
using System.Linq;
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
                WorkOrderId = input.WorkOrderId,
                TimeEntries = input.TimeEntries.Select(t => t.ToTimeEntry()).ToList(),
                Materials = input.MaterialWorkOrders.Select(m => m.Material.ToMaterial()).ToList()
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

        public static Transform.Material ToMaterial(this Material input)
        {
            return new Transform.Material
            {
                Id = input.Id,
                Name = input.Name,
                Cost = input.Cost,
                UnitOfMeasure = input.UnitOfMeasure.ToUnitOfMeasure()
            };
        }

        public static Transform.UnitOfMeasure ToUnitOfMeasure(this UnitOfMeasure input)
        {
            return new Transform.UnitOfMeasure
            {
                Id = input.Id,
                Name = input.Name, 
                Value = input.Value, 
                UnitType = input.UnitType
            };
        }

        public static Transform.Company ToCompany(this Company input)
        {
            return new Transform.Company
            {
                Id = input.Id,
                Name = input.Name,
                Addresses = input.Addresses?.ToList() ?? new List<Address>(),
                Projects = input.Projects?.Select(p => p.ToProject()).ToList() ?? new List<Transform.Project>(),
                DateAdded = input.DateAdded
            };
        }
    }
}
