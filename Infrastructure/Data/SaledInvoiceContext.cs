using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SaledInvoiceContext : DbContext
    {
        public SaledInvoiceContext(DbContextOptions options ): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<defCustomer> Customers { get; set; }
        public virtual DbSet<DefItem> DefItems  { get; set; }
        public virtual DbSet<DefStore> DefStores  { get; set; }
        public virtual DbSet<TrxInvoiceDetails> TrxInvoiceDetails { get; set; }
        public virtual DbSet<TrxInvoiceHead> TrxInvoiceHeads { get; set; }
    }
}
