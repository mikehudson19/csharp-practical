using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Data
{
    public interface IFullStackRepository
    {
        User GetUser(int id);
        List<User> GetUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);

        Invoice GetInvoice(int id);
        List<Invoice> GetInvoices(bool includeChildren);
        Invoice CreateInvoice(Invoice user);
        Invoice UpdateInvoice(Invoice user);
        void DeleteInvoice(int id);

        InvoiceItem GetInvoiceItem(int id);
        List<InvoiceItem> GetInvoiceItems();
        InvoiceItem CreateInvoiceItem(InvoiceItem user);
        InvoiceItem UpdateInvoiceItem(InvoiceItem user);
        void DeleteInvoiceItem(int id);
    }

    public class FullStackRepository : IFullStackRepository
    {
        private FullStackDbContext _ctx;
        public FullStackRepository(FullStackDbContext ctx)
        {
            _ctx = ctx;
        }

        #region User CRUD Methods
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
            //return _ctx.Users.ToList();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
            //return _ctx.Users.Find(id);
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();

            //_ctx.Users.Add(e);
            //_ctx.SaveChanges();
            //return e;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();

            //var existing = _ctx.Users.SingleOrDefault(em => em.Id == e.Id);
            //if (existing == null) return null;

            //_ctx.Entry(existing).State = EntityState.Detached;
            //_ctx.Users.Attach(e);
            //_ctx.Entry(e).State = EntityState.Modified;
            //_ctx.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();

            //var entity = _ctx.Users.Find(noteId);
            //_ctx.Users.Remove(entity); //CAREFULL!! here when you copy and paste, change _ctx.Users to the new DBSet
            //_ctx.SaveChanges();
        }
        #endregion

        #region Invoice CRUD methods
        public List<Invoice> GetInvoices(bool includeChildren)
        {
            if (includeChildren)
            {
                return _ctx.Invoices.Include(i => i.InvoiceItems).ToList();
            }
            return _ctx.Invoices.ToList();
        }

        public Invoice GetInvoice(int id)
        {
            var invoiceWithItems = _ctx.Invoices.Include(i => i.InvoiceItems).ToList();
            return _ctx.Invoices.Find(id);
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            _ctx.Invoices.Add(invoice);
            _ctx.SaveChanges();
            return invoice;
        }

        public Invoice UpdateInvoice(Invoice invoice)
        {

            var existing = _ctx.Invoices.SingleOrDefault(em => em.Id == invoice.Id);
            if (existing == null) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.Invoices.Attach(invoice);
            _ctx.Entry(invoice).State = EntityState.Modified;
            _ctx.SaveChanges();
            return invoice;
        }

        public void DeleteInvoice(int id)
        {
            var entity = _ctx.Invoices.Find(id);
            _ctx.Invoices.Remove(entity); //CAREFULL!! here when you copy and paste, change _ctx.Users to the new DBSet
            _ctx.SaveChanges();
        }
        #endregion

        #region InvoiceItem CRUD methods
        public List<InvoiceItem> GetInvoiceItems()
        {
            //throw new NotImplementedException();
            return _ctx.InvoiceItems.ToList();
        }

        public InvoiceItem GetInvoiceItem(int id)
        {
            //throw new NotImplementedException();
            return _ctx.InvoiceItems.Find(id);
        }

        public InvoiceItem CreateInvoiceItem(InvoiceItem item)
        {
            //throw new NotImplementedException();

            _ctx.InvoiceItems.Add(item);
            _ctx.SaveChanges();
            return item;
        }

        public InvoiceItem UpdateInvoiceItem(InvoiceItem item)
        {
            //throw new NotImplementedException();

            var existing = _ctx.InvoiceItems.SingleOrDefault(em => em.Id == item.Id);
            if (existing == null) return null;

            _ctx.Entry(existing).State = EntityState.Detached;
            _ctx.InvoiceItems.Attach(item);
            _ctx.Entry(item).State = EntityState.Modified;
            _ctx.SaveChanges();
            return item;
        }

        public void DeleteInvoiceItem(int id)
        {
            //throw new NotImplementedException();

            var entity = _ctx.InvoiceItems.Find(id);
            _ctx.InvoiceItems.Remove(entity); //CAREFULL!! here when you copy and paste, change _ctx.Users to the new DBSet
            _ctx.SaveChanges();
        }
        #endregion
    }
}
