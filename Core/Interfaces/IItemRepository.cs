using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task AddItem(DefItem item);
        IQueryable GetItems();
        public void CreateInvoice(TrxInvoiceDetails trxInvoiceDetails);

        public void AddInvoiceHead(TrxInvoiceHead trxInvoiceHead);
    }
}
