using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DefStore
    {
        [Key]
        public int StoreID { get; set; }
        public int StoreSerial { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string StoreArName { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string StoreEnName { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string Notes { get; set; }


        public virtual List<TrxInvoiceHead> Invoices { get; set; }
    }
}
