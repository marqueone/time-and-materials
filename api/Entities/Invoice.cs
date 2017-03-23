using System;
using System.Collections.Generic;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    public class Invoice 
    {
        public int Id  {get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }
        public Address BillingAddress { get; set; }
        public int CompanyId { get; set; }
        public bool IsPaid { get; set; }
    }
}