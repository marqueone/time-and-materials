using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marqueone.TimeAndMaterials.Api.Entities;

namespace Marqueone.TimeAndMaterials.Api.Models.Relationships
{
    [Table("employee_trade")]
    public class EmployeeTrade
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Column]
        public int TradeId { get; set; }
        public virtual Trade Trade { get; set; }
    }
}