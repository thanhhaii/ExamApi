using ExamApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApi.Services
{
    public class InvoiceServiceImpl : IInvoiceService
    {
        private readonly DatabaseContext _databaseContext;

        public InvoiceServiceImpl(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            await _databaseContext.AddAsync(invoice);
            await _databaseContext.SaveChangesAsync();
            return invoice;
        }

        public async Task Delete(int id)
        {
            var invoice = await _databaseContext.Invoices.FindAsync(id);
            invoice.Status = false;
            await _databaseContext.SaveChangesAsync();
        }

        public List<Invoice> GetAllInvoice(int totalInvoice)
        {
            return _databaseContext.Invoices.Where(i => i.Status == true).OrderByDescending(x => x.Created).Take(totalInvoice).ToList();
        }

        public List<Invoice> GetInvoiceBasedOnPayment(string payment, int min, int max)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Read(int id)
        {
            return await _databaseContext.Invoices.FindAsync(id);
        }

        public int TotalInvoiceInOneMonthOfYear(int month, int year)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Update(Invoice invoice)
        {
            _databaseContext.Entry(invoice).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return await _databaseContext.Invoices.FindAsync(invoice.Id);
        }
    }
}
