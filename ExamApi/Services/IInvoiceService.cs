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
        public double TotalInvoiceInOneMonthOfYear(int month, int year);
        public Invoice Create(Invoice invoice);
        public Invoice Read(int id);
        public Invoice Update(Invoice invoice);
        public void Delete(int id);

        public List<Invoice> GetAllInvoice();
    }
}
