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

        [HttpGet]
        public IActionResult GetInvoices()
        {
            // Get invoices from repo
            var invoices = _repo.GetInvoices();

            var invoicesToReturn = new List<InvoiceDTO>();

            foreach (var invoice in invoices)
            {
                // Map invoice items to DTO
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

                // Map invoice to DTO
                invoicesToReturn.Add(new InvoiceDTO()
                {
                    Id = invoice.Id,
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

            if (invoice == null)
            {
                return NotFound();
            }

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
                Id = invoice.Id,
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

            // Map invoice items to data object
            var invoiceItems = new List<DataInvoiceItem>();

            foreach (var item in newInvoice.InvoiceItems)
            {
                invoiceItems.Add(new DataInvoiceItem() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate, Total = item.Total });
            }

            // Map new invoice the invoice data object
            var invoiceEntity = new DataInvoice()
            {
                InvoiceNumber = newInvoice.InvoiceNumber,
                InvoiceDate = newInvoice.InvoiceDate,
                InvoiceTotal = newInvoice.InvoiceTotal,
                InvoiceItems = invoiceItems,
                DueDate = newInvoice.DueDate
            };

            // Save new invoice via repository
            var createdItem = _repo.CreateInvoice(invoiceEntity);

            // Map invoice saved to DB to a DTO
            var invoiceItemsToReturn = new List<InvoiceItemDTO>();

            foreach (var item in newInvoice.InvoiceItems)
            {
                invoiceItemsToReturn.Add(new InvoiceItemDTO() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate, Total = item.Total });
            }

            var invoiceToReturn = new InvoiceDTO()
            {
                Id = invoiceEntity.Id,
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
        public ActionResult UpdateInvoice(int id, DataInvoice invoice)
        {
            var invoiceEntity = _repo.GetInvoice(id);

            if (invoiceEntity == null)
            {
                return NotFound();
            }

            invoiceEntity.InvoiceNumber = invoice.InvoiceNumber;
            invoiceEntity.InvoiceTotal = invoice.InvoiceTotal;

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
