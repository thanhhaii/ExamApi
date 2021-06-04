using ExamApi.Models;
using ExamApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("take-n-invoice")]
        [Consumes("application/json")]
        public IActionResult TakeNInvoice([FromQuery(Name = "numberOfInvoice")]int n)
        {
            try
            {                
                return Ok(_invoiceService.GetAllInvoice(n));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("listed-invoice")]
        [Consumes("application/json")]
        public IActionResult ListedInvoice([FromQuery(Name = "payment")]string payment, [FromQuery(Name ="max")]int max, [FromQuery(Name ="min")]int min)
        {
            try
            {
                return Ok(_invoiceService.GetInvoiceBasedOnPayment(payment,min, max));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("total-invoice-in-month-of-year")]
        [Consumes("text/plain")]
        public IActionResult TotalInvoiceInMonthOfYear([FromQuery(Name = "month")]int month, [FromQuery(Name = "year")]int year) 
        {
            try
            {
                return Ok(_invoiceService.TotalInvoiceInOneMonthOfYear(month, year));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("invoice/{id}")]
        [Consumes("application/json")]
        public IActionResult GetInvoice(int id)
        {
            try
            {
                return Ok(_invoiceService.Read(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("invoice")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult CreateInvoice([FromBody]Invoice invoice)
        {
            try
            {
                return Ok(_invoiceService.Create(invoice));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("invoice")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateInvoice([FromBody]Invoice invoice)
        {
            try
            {
                return Ok(_invoiceService.Update(invoice));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("invoice/{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            try
            {
                _invoiceService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
