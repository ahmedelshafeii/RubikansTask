using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private SaledInvoiceContext _context;

        public CustomerRepository(SaledInvoiceContext context)
        {
            _context = context;
        }

        public async Task createCustomer(defCustomer defCustomer)
        {
            await _context.Customers.AddAsync(defCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<defCustomer>> getAllCustomers()
        {
            List<defCustomer>? customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<defCustomer> getCustomer(int id)
        {
            defCustomer? customer= await _context.Customers.FindAsync(id);
            return customer;
        }
    }
}
