
using ContactSync.Context;
using ContactSync.Entities;
using ContactSync.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContactSync.Repository
{
    public class ContactGroupRepository : IContactGroupRepository
    {
        private readonly ContactSyncContext contactSyncContext;

        public ContactGroupRepository(ContactSyncContext contactSyncContext)
        {
            this.contactSyncContext = contactSyncContext;
        }

        public int AddContactGroup(ContactGroup phoneBook)
        {
            contactSyncContext.ContactGroups.Add(phoneBook);
            return Save();
        }

        public IEnumerable<ContactGroup> GetAllContactGroups()
        {
            return contactSyncContext.ContactGroups.ToList();
        }

        public ContactGroup GetContactGroupById(long id, string includedFields = "")
        {
            IQueryable<ContactGroup> phoneBooksQuery = contactSyncContext.ContactGroups;

            phoneBooksQuery = phoneBooksQuery.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(includedFields))
            {
                foreach (var field in includedFields.Split(",", System.StringSplitOptions.RemoveEmptyEntries))
                    phoneBooksQuery = phoneBooksQuery.Include(field);
            }

            return phoneBooksQuery.FirstOrDefault();
        }

        public int UpdateContactGroup(ContactGroup phoneBook)
        {
            contactSyncContext.Attach(phoneBook);
            contactSyncContext.Entry(phoneBook).State = EntityState.Modified;

            return Save();
        }

        private int Save()
        {
            return contactSyncContext.SaveChanges();
        }
    }
}
