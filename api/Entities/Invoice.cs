using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marqueone.TimeAndMaterials.Api.Entities
{
    [Table(name: "invoices")]
    public class Invoice 
    {
        [Key]
        [Column]
        public int Id  {get; set; }

        [Column]
        [Required]
        [MaxLength(16)]
        public string InvoiceNumber { get; set; }

        [Column]
        [Required]
        public DateTime InvoiceDate { get; set; }

        [Column]
        [Required]
        public DateTime DueDate { get; set; }

        public virtual IList<WorkOrder> WorkOrders { get; set; }

        [Column]
        [Required]
        public Address BillingAddress { get; set; }

        [Column]
        public bool IsPaid { get; set; }
    }
}