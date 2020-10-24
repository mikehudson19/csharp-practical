using System;
using FullStack.Data;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IFullStackRepository _repo; 

        public InvoicesController(IFullStackRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _repo.GetInvoices();
            return Ok(invoices);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _repo.GetInvoice(id);
            return Ok(invoice);
        }
    }
}
