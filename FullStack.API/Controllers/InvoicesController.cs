using System;
using FullStack.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using FullStack.ViewModels;
using System.Collections.Generic;
using CSharp.Domain;
using FullStack.Data;

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

        // NEED TO CREATE DTO'S TO MAP THE INVOICES TO BEFORE RETURNING.
        // CREATE STATIC HELPER FUNCTIONS FOR THE MAPPING

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = _repo.GetInvoices();

            var invoicesToReturn = new List<InvoiceDTO>();

            foreach (var invoice in invoices)
            {
                var invoiceItems = new List<InvoiceItemDTO>();

                foreach (var item in invoice.InvoiceItems)
                {
                    invoiceItems.Add(new InvoiceItemDTO()
                    {
                        ItemName = item.ItemName,
                        ItemRate = item.ItemRate,
                        Description = item.Description,
                        Hours = item.Hours,
                        Total = item.Total
                    });
                }

                invoicesToReturn.Add(new InvoiceDTO()
                {
                    InvoiceNumber = invoice.InvoiceNumber,
                    InvoiceDate = invoice.InvoiceDate,
                    DueDate = invoice.DueDate,
                    InvoiceItems = invoiceItems,
                    InvoiceTotal = invoice.InvoiceTotal
                });
            }
            return Ok(invoicesToReturn);
        }

        [HttpGet]
        [Route("{id}", Name = "GetInvoice")]
        public IActionResult GetInvoice(int id)
        {
            var invoice = _repo.GetInvoice(id);

            var invoiceItems = new List<InvoiceItemDTO>();

            foreach (var item in invoice.InvoiceItems)
            {
                invoiceItems.Add(new InvoiceItemDTO()
                {
                    ItemName = item.ItemName,
                    ItemRate = item.ItemRate,
                    Description = item.Description,
                    Hours = item.Hours,
                    Total = item.Total
                });
            }

            var invoiceToReturn = new InvoiceDTO()
            {
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                InvoiceItems = invoiceItems,
                InvoiceTotal = invoice.InvoiceTotal
            };

            return Ok(invoiceToReturn);
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> CreateInvoice()
        {
            var newInvoice = InvoiceGenerator.GenerateInvoice("INV040", 3, 3);

            var invoiceItems = new List<DataInvoiceItem>();

            foreach (var item in newInvoice.InvoiceItems)
            {
                invoiceItems.Add(new DataInvoiceItem() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate, Total = item.Total });
            }

            var invoiceEntity = new DataInvoice()
            {
                InvoiceNumber = newInvoice.InvoiceNumber,
                InvoiceDate = newInvoice.InvoiceDate,
                InvoiceTotal = newInvoice.InvoiceTotal,
                InvoiceItems = invoiceItems,
                DueDate = newInvoice.DueDate
            };

            var createdItem = _repo.CreateInvoice(invoiceEntity);

            var invoiceItemsToReturn = new List<InvoiceItemDTO>();

            foreach (var item in newInvoice.InvoiceItems)
            {
                invoiceItemsToReturn.Add(new InvoiceItemDTO() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate, Total = item.Total });
            }

            var invoiceToReturn = new InvoiceDTO()
            {
                InvoiceNumber = invoiceEntity.InvoiceNumber,
                InvoiceDate = invoiceEntity.InvoiceDate,
                InvoiceItems = invoiceItemsToReturn,
                DueDate = invoiceEntity.DueDate,
                InvoiceTotal = invoiceEntity.InvoiceTotal
            };

            return CreatedAtRoute("GetInvoice",
                                  new { id = createdItem.Id },
                                  invoiceToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInvoice(int id)
        {
            // Check if not null

            var invoiceEntity = _repo.GetInvoice(id);

            var updatedInvoice = InvoiceGenerator.GenerateInvoice("INV105", 2, 4);

            invoiceEntity.InvoiceNumber = updatedInvoice.InvoiceNumber;

            _repo.UpdateInvoice(invoiceEntity);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteInvoice(int id)
        {
            _repo.DeleteInvoice(id);

            return NoContent();
        }
    }
}
