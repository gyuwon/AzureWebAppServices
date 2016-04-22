using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ContactManager.Models
{
    public class ContactRepository
    {
        private static int _lastId = 1;

        private static ConcurrentDictionary<int, Contact> _storage =
            new ConcurrentDictionary<int, Contact>
            {
                [1] = new Contact
                {
                    Id = 1,
                    FirstName = "Gyuwon",
                    LastName = "Yi",
                    Email = "gyuwon.yi@outlook.com"
                }
            };

        public IEnumerable<Contact> GetAllContacts() => _storage.Values;

        public Contact FindContact(int id)
        {
            Contact contact;
            return _storage.TryGetValue(id, out contact) ? contact : null;
        }

        public void InsertContact(Contact contact)
        {
            int id = Interlocked.Increment(ref _lastId);
            _storage.TryAdd(id, contact);
            contact.Id = id;
        }

        public bool UpdateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            Contact value;
            return _storage.TryGetValue(contact.Id, out value)
                && _storage.TryUpdate(contact.Id, contact, value);
        }

        public bool DeleteContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            return _storage.TryRemove(contact.Id, out contact);
        }
    }
}
