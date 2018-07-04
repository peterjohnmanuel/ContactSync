
using ContactSync.Context;
using ContactSync.Entities;
using ContactSync.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ContactSync.Repository
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly ContactSyncContext contactSyncContext;

        public PhoneBookRepository(ContactSyncContext contactSyncContext)
        {
            this.contactSyncContext = contactSyncContext;
        }

        public int AddNewPhoneBook(PhoneBook phoneBook)
        {
            contactSyncContext.PhoneBooks.Add(phoneBook);
            return Save();
        }

        public IEnumerable<PhoneBook> GetAllPhoneBooks()
        {
            return contactSyncContext.PhoneBooks.ToList();
        }

        public PhoneBook GetPhoneBookById(long id)
        {
            return contactSyncContext.PhoneBooks.Find(id);
        }

        private int Save()
        {
            return contactSyncContext.SaveChanges();
        }
    }
}
