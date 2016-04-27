using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContactManager.Models
{
    public class ContactRepository : IDisposable
    {
        private readonly ContactManagerDbContext _dbContext;

        public ContactRepository()
        {
            _dbContext = new ContactManagerDbContext();
        }

        public virtual IEnumerable<Contact> GetAllContacts() =>
            _dbContext.Contacts.ToList();

        public virtual Contact FindContact(int id) =>
            _dbContext.Contacts.Find(id);

        public virtual void InsertContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        public virtual bool UpdateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _dbContext.Entry(contact).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool DeleteContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _dbContext.Entry(contact).State = EntityState.Deleted;
            return _dbContext.SaveChanges() > 0;
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
