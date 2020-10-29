using System;
using FullStack.Data;
using FullStack.ViewModels;
using System.Collections.Generic;
using FullStack.Data.Entities;
using System.Linq;
using CSharp.Domain;

namespace FullStack.API.Services
{
    public class InvoiceService
    {
        private readonly IFullStackRepository _repo;

        public InvoiceService(IFullStackRepository repo)
        {
            this._repo = repo;
        }

        public List<InvoiceDTO> GetInvoices()
        {
            var invoices = this._repo.GetInvoices(includeChildren: true);
            return MapInvoices(invoices);
        }

        internal List<InvoiceDTO> MapInvoices(List<Invoice> invoices)
        {
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
                        Hours = item.Hours
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
                    InvoiceTotal = invoiceItems.Sum(invoiceItems => invoiceItems.Total)
                });

            }

            return invoicesToReturn;

        }

        internal InvoiceDTO GetInvoice(int id)
        {
            var invoice = _repo.GetInvoice(id);
            return MapInvoice(invoice);
        }

        internal InvoiceDTO MapInvoice(Invoice invoice)     
        {
            var invoiceItems = new List<InvoiceItemDTO>();

            foreach (var item in invoice.InvoiceItems)
            {
                invoiceItems.Add(new InvoiceItemDTO()
                {
                    ItemName = item.ItemName,
                    ItemRate = item.ItemRate,
                    Description = item.Description,
                    Hours = item.Hours
                });
            }

            var invoiceToReturn = new InvoiceDTO()
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                InvoiceItems = invoiceItems,
                InvoiceTotal = invoiceItems.Sum(s => s.Total)
            };

            return invoiceToReturn;
        }

        internal Invoice MapForCreation(InvoiceEntity newInvoice)
        {
            var invoiceItems = new List<InvoiceItem>();

            foreach (var item in newInvoice.InvoiceItems)
            {
                invoiceItems.Add(new InvoiceItem() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate });
            }

            // Map new invoice the invoice data object
            var invoiceEntity = new Invoice()
            {
                InvoiceNumber = newInvoice.InvoiceNumber,
                InvoiceDate = newInvoice.InvoiceDate,
                InvoiceItems = invoiceItems,
                DueDate = newInvoice.DueDate
            };

            return invoiceEntity;       
        }

        internal Invoice CreateInvoice(Invoice invoice)
        {
            var createdItem = _repo.CreateInvoice(invoice);
            return createdItem;

        }

        internal void UpdateInvoice(InvoiceDTO invoice)
        {
            var mappedInvoice = MapToDataObject(invoice);

            _repo.UpdateInvoice(mappedInvoice);   
        }

        internal Invoice MapToDataObject(InvoiceDTO invoice)
        {
            var invoiceToReturn = new Invoice()
            {
                Id = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber
            };

            return invoiceToReturn;
        }

        internal void DeleteInvoice(int id)
        {
            _repo.DeleteInvoice(id);
        }
    }   
}
