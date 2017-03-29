using System;
using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Models.Transforms
{
    public class Company 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Entities.Address> Addresses { get; set; }
        public IList<Project> Projects { get; set; }
        public DateTime DateAdded { get; set; }
    }
}