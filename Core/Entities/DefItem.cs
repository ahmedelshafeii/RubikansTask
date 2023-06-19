using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DefItem
    {
        [Key]
        public int ItemID { get; set; }

        public int ItemSerial { get; set; }

        [Column(TypeName ="nvarchar(200)")]
        public string ItemArName { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string ItemEnName { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string Notes { get; set; }
        [Column(TypeName ="DECIMAL(18,2)")]
        public float Price { get; set; }
        [Column(TypeName ="DECIMAL(5,2)")]
        public float Vat { get; set; }

        // navigation Props
        public virtual List<TrxInvoiceDetails> InvoiceDetails { get; set; }


    }
}
