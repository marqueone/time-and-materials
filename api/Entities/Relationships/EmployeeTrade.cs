using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities.Relationships
{
    [Table(name: "employee_trade")]
    public class EmployeeTrade
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int TradeId { get; set; }
        public virtual Trade Trade { get; set; }
    }
}