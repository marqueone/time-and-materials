using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities.Relationships
{
    [Table(name: "material_work_order")]
    public class MaterialWorkOrder
    {
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}