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
    public class StoreRepository : IStoreRepository
    {
        private SaledInvoiceContext _context;
        public StoreRepository(SaledInvoiceContext context) {
            this._context=context;
        }

        public async Task Createstore(DefStore store)
        {
            await _context.DefStores.AddAsync(store);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DefStore>> GetAllStores()
        {
            return await _context.DefStores.ToListAsync();
        }

        public async Task<DefStore> GetStore(int id)
        {
            return await _context.DefStores.FindAsync(id);
        }
    }
}
