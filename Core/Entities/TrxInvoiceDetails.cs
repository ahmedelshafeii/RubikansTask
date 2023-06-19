using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrxInvoiceDetails
    {
        [Key]
        public int InvoiceDetID { get; set; }

        [ForeignKey("TrxInvoiceHead")]
        public int InvoiceID { get; set; }
        [ForeignKey("DefItem")]
        public int ItemID { get; set; }


        [Column(TypeName ="DECIMAL(18,2)")]
        public float Qty { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float Price { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float TotalValue { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float CashDiscPercent { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float TotalAfterDiscount { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float TaxPercent { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float TotalInvoiceNet { get; set; }




        // Navigation Props
        public virtual TrxInvoiceHead TrxInvoiceHead { get; set; }
        public virtual DefItem DefItem { get; set; }



    }
}
