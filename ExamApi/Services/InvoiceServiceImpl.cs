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

        public Invoice Create(Invoice invoice)
        {
            _databaseContext.AddAsync(invoice);
            _databaseContext.SaveChanges();
            return invoice;
        }

        public void Delete(int id)
        {
            var invoice = _databaseContext.Invoices.Find(id);
            invoice.Status = false;
            _databaseContext.SaveChanges();
        }

        public List<Invoice> GetAllInvoice(int totalInvoice)
        {
            return _databaseContext.Invoices.Where(i => i.Status == true).OrderByDescending(x => x.Created).Take(totalInvoice).ToList();
        }

        public List<Invoice> GetAllInvoice()
        {
            return _databaseContext.Invoices.Where(i => i.Status == true).ToList();
        }

        public List<Invoice> GetInvoiceBasedOnPayment(string payment, int min, int max)
        {
            return _databaseContext.Invoices.Where(i => i.Status == true && i.Payment == payment && i.Total >= min && i.Total <= max).ToList();
        }

        public Invoice Read(int id)
        {
            return _databaseContext.Invoices.Find(id);
        }

        public double TotalInvoiceInOneMonthOfYear(int month, int year)
        {
            return (double)_databaseContext.Invoices.Where(i => i.Created.Value.Month == month && i.Created.Value.Year == year).Sum(i => i.Total);
        }

        public Invoice Update(Invoice invoice)
        {
            _databaseContext.Entry(invoice).State = EntityState.Modified;
            _databaseContext.SaveChangesAsync();
            return _databaseContext.Invoices.Find(invoice.Id);
        }
    }
}
