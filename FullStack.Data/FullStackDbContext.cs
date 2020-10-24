using System;
using System.Collections.Generic;
using System.Text;
using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using CSharp.Domain;

namespace FullStack.Data
{
    public class FullStackDbContext : DbContext
    {
        public DbSet<DataInvoice> Invoices { get; set; }
        public DbSet<DataInvoiceItem> InvoiceItems { get; set; }

        public FullStackDbContext(DbContextOptions<FullStackDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public void addInvoice() // For test purposes to check that I can persist to the DB.
        {
            var invoice = InvoiceGenerator.GenerateInvoice();

            var invoiceItems = new List<DataInvoiceItem>();

            foreach (var item in invoice.InvoiceItems)
            {
                invoiceItems.Add(new DataInvoiceItem() { ItemName = item.ItemName, Description = item.Description, Hours = item.Hours, ItemRate = item.ItemRate, Total = item.Total });
            }

            var dbInvoice = new DataInvoice()
            {
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                InvoiceTotal = invoice.InvoiceTotal,
                InvoiceItems = invoiceItems
            };

            Invoices.Add(dbInvoice);
            this.SaveChanges();
        }
    }
}
