﻿// <auto-generated />
using System;
using FullStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStack.Data.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    [Migration("20201023134011_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("FullStack.Data.Entities.DataInvoice", b =>
                {
                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("InvoiceDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("TEXT");

                    b.ToTable("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
