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

        public FullStackDbContext(DbContextOptions<FullStackDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            addInvoice();
        }

        public void addInvoice()
        {
            var invoice = InvoiceGenerator.GenerateInvoice();

            var dbInvoice = new DataInvoice()
            {
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                InvoiceTotal = invoice.InvoiceTotal
                //InvoiceItems = invoice.InvoiceItems
            };

            Invoices.Add(dbInvoice);
            this.SaveChanges();
            Console.WriteLine("Succesfully saved to database");
        }



    }
}
