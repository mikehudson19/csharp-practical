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
            addInvoice();
        }

        public void addInvoice()
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
                InvoiceItems = new List<DataInvoiceItem>()
                {
                    new DataInvoiceItem() { ItemName = "The Newer item", Description = "The newer description", Hours = 3, ItemRate = 300, Total = 300 }
                }
            };

            Invoices.Add(dbInvoice);
            this.SaveChanges();
            Console.WriteLine("Succesfully saved to database");
        }



    }
}
