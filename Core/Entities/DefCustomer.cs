using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class defCustomer
    {
        [Key]
        public int CustomerID { get; set; }
        public int CustomerSerial { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string CustomerArName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string CustomerEnName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Notes { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public float CashDiscPercent { get; set; }

        public virtual List<TrxInvoiceHead> Invoices { get; set; }
    }
}
