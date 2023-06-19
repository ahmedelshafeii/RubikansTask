using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        SaledInvoiceContext _context;
        public ItemRepository(SaledInvoiceContext context) { 
            this._context = context;
        }
        public async Task AddItem(DefItem item)
        {
            await _context.DefItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetItems()
        {
            var x = _context.TrxInvoiceDetails.Include(x => x.DefItem).Select(v => new
            {
                name =string.Format("{0} - {1}", v.DefItem.ItemEnName , v.DefItem.ItemArName),
                price = v.DefItem.Price,
                vat = v.DefItem.Vat,
                value = (v.Qty * v.DefItem.Price) * (v.CashDiscPercent / 100),
                taxValue = v.TotalValue * (v.DefItem.Vat / 100),
                totalInvoice = v.TotalValue * (v.TotalValue * (v.DefItem.Vat / 100)),
                cashDesc = v.CashDiscPercent,
                notes = v.DefItem.Notes,
                qty = v.Qty

            });
            return x;
        }

        public void CreateInvoice(TrxInvoiceDetails trxInvoiceDetails)
        {
            _context.TrxInvoiceDetails.Add(trxInvoiceDetails);
            _context.SaveChanges();
        }

        public void AddInvoiceHead(TrxInvoiceHead trxInvoiceHead)
        {
            _context.TrxInvoiceHeads.Add(trxInvoiceHead);
            _context.SaveChanges();
        }
    }
}
