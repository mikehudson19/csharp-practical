using System;
using System.Collections.Generic;
using CSharp.Domain;
using System.Text.RegularExpressions;


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

            string myString = "INV1561";
            string pattern = @"^[I][N][V][0-9]{4}$";
            Regex regex = new Regex(pattern);
            Console.WriteLine(regex.IsMatch(myString));


            Console.ReadLine();
        }
    }
}
