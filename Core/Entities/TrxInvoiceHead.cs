using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrxInvoiceHead
    {
        [Key]
        public int InvoiceID { get; set; }
        public int InvoiceSerial { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("defCustomer")]
        public int CustomerID { get; set; }

        [ForeignKey("DefStore")]
        public int StoreID { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public float TotalbeforeDiscount { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public float TotalDiscount { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public float TotalAfterDiscount { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public float TotalTax { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public float TotalInvoiceNet { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string InvoiceDescription { get; set; }


        // navigation Props
        public virtual DefStore DefStore { get; set; }
        public virtual defCustomer defCustomer { get; set; }

        public virtual List<TrxInvoiceDetails> TrxInvoiceDetails { get; set; }

    }
}
