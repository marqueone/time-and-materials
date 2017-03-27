using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Marqueone.TimeAndMaterials.Api.Models;
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

        [Column]
        [Required]
        public EmployeeType Type { get; set; }
        
        public virtual IList<EmployeeTrade> EmployeeTrades { get; set; }
        public virtual IList<ContactMethod> Contacts { get; set; }

        public Transform.Employee ToTransform()
        {
            var transform = new Transform.Employee
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Type = Type,
                Contacts = Contacts,
                Trades = new List<Transform.Trade>()
            };

            foreach (var item in EmployeeTrades)
            {
                if(item.Trade != null){
                    transform.Trades.Add(new Transform.Trade()
                    {
                        Id = item.Trade.Id,
                        Name = item.Trade.Name,
                        PayRate = item.Trade.PayRate,
                        IsActive = item.Trade.IsActive
                    });
                }
            }

            return transform;
        }
    }
}