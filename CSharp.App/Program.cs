using System;
using System.Collections.Generic;
using CSharp.Domain;

namespace CSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Invoice> invoices = InvoiceGenerator.GenerateInvoices();

            foreach (var i in invoices)
            {
                Console.WriteLine(i.ToString());
            }

            Console.ReadLine();
        }
    }
}
