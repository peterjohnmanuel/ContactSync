
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

        public int AddContactGroup(ContactGroup contactGroup)
        {
            contactSyncContext.ContactGroups.Add(contactGroup);
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

        public int UpdateContactGroup(ContactGroup contactGroup)
        {
            contactSyncContext.Attach(contactGroup);
            contactSyncContext.Entry(contactGroup).State = EntityState.Modified;

            return Save();
        }

        private int Save()
        {
            return contactSyncContext.SaveChanges();
        }
    }
}
