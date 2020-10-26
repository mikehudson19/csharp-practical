﻿using System;
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
    }
}
