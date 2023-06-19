using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class InvoiceDetailsDTO
    {
        public int InvoiceID { get; set; }
        public int ItemID { get; set; }
        public float Qty { get; set; }
        public float Price { get; set; }
        public float TotalValue { get; set; }
        public float CashDiscPercent { get; set; }
        public float TotalAfterDiscount { get; set; }
        public float TaxPercent { get; set; }
        public float TotalInvoiceNet { get; set; }
    }
}
