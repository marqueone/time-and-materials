using System;
using System.Collections.Generic;
using Marqueone.TimeAndMaterials.Api.Models;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ProjectedEnd { get; set; }
        public bool IsComplete { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }
    }
}