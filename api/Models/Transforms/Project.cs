using System;
using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ProjectedEnd { get; set; }
        IList<WorkOrder> WorkOrders { get; set; }
    }
}