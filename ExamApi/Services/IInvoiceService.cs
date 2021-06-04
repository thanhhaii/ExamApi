using ExamApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApi.Services
{
    public interface IInvoiceService
    {

        public List<Invoice> GetAllInvoice(int totalInvoice);
        public List<Invoice> GetInvoiceBasedOnPayment(string payment, int min, int max);
        public int TotalInvoiceInOneMonthOfYear(int month, int year);
        public Task<Invoice> Create(Invoice invoice);
        public Task<Invoice> Read(int id);
        public Task<Invoice> Update(Invoice invoice);
        public Task Delete(int id);
    }
}
