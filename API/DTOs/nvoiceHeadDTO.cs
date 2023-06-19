using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class nvoiceHeadDTO
    {
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public int InvoiceSerial { get; set; }
        public int CustomerID { get; set; }
        public int StoreID { get; set; }
        public float TotalbeforeDiscount { get; set; }
        public float TotalDiscount { get; set; }
        public float TotalAfterDiscount { get; set; }
        public float TotalTax { get; set; }
        public float TotalInvoiceNet { get; set; }
        public string InvoiceDescription { get; set; }

    }
}
