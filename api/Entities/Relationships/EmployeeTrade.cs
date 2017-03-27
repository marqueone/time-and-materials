namespace Marqueone.TimeAndMaterials.Api.Entities.Relationships
{
    public class EmployeeTrade
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TradeId { get; set; }
        public Trade Trade { get; set; }
    }
}