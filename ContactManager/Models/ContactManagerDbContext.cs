using System.Data.Entity;

namespace ContactManager.Models
{
    public class ContactManagerDbContext : DbContext
    {
        public ContactManagerDbContext()
            : base(nameOrConnectionString: nameof(ContactManagerDbContext))
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
