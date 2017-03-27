using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "employees")]
    public class Employee 
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [Column]
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        
        public ICollection<EmployeeTrade> EmployeeTrades { get; set; }

        public Transform.Employee ConvertToEmployee()
        {
            Transform.Employee transform = new Transform.Employee
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName
            };

            return transform;
        }
    }
}