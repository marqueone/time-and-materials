using System;
using System.ComponentModel.DataAnnotations;

namespace Marqueone.TimeAndMaterials.Api.Models.ViewModels
{
    public class NewProjectViewModel 
    {
        public string Name { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ProjectedEnd { get; set; }
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
}