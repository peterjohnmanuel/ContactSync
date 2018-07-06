using System.Linq;
using ContactSync.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSync.Context
{
    public class ContactSyncContext : DbContext
    {
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ContactSyncContext(DbContextOptions<ContactSyncContext> options) : base(options)
        {
        }
    }
}
