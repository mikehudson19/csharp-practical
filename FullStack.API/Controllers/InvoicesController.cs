using System;
using FullStack.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using FullStack.ViewModels;
using System.Collections.Generic;
using CSharp.Domain;
using FullStack.Data;
using System.Linq;
using FullStack.API.Services;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IFullStackRepository _repo;
        private readonly InvoiceService _invoiceService;

        public InvoicesController(IFullStackRepository repo, InvoiceService invoiceService)
        {
            this._repo = repo;
            this._invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _invoiceService.GetInvoices();
            return Ok(invoices);
        }


        [HttpGet]
        [Route("{id}", Name = "GetInvoice")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _invoiceService.GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }


        [HttpPost]
        public ActionResult<InvoiceDTO> CreateInvoice()
        {
            var newInvoice = InvoiceGenerator.GenerateInvoice("INV040", 3, 3);

            var mappedInvoice = _invoiceService.MapForCreation(newInvoice);

            var createdInvoice = _invoiceService.CreateInvoice(mappedInvoice);

            var invoiceToReturn = _invoiceService.MapInvoice(mappedInvoice);

            return CreatedAtRoute("GetInvoice",
                                  new
                                  {
                                      id = createdInvoice.Id
                                  },
                                  invoiceToReturn);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateInvoice(int id, InvoiceDTO invoice)
        {
            var invoiceFromDb = _invoiceService.GetInvoice(id); 

            if (invoiceFromDb == null)
            {
                return NotFound();
            }

            invoiceFromDb.InvoiceNumber = invoice.InvoiceNumber;

            _invoiceService.UpdateInvoice(invoiceFromDb);

            return NoContent();
        }

            
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteInvoice(int id)
        {
            _invoiceService.DeleteInvoice(id);

            return NoContent();
        }
    }
}
