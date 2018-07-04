
using ContactSync.Context;
using ContactSync.Entities;
using ContactSync.IRepository;
using Microsoft.EntityFrameworkCore;
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

        public PhoneBook GetPhoneBookById(long id, string includedFields = "")
        {
            IQueryable<PhoneBook> phoneBooksQuery = contactSyncContext.PhoneBooks;

            phoneBooksQuery = phoneBooksQuery.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(includedFields))
            {
                foreach (var field in includedFields.Split(",", System.StringSplitOptions.RemoveEmptyEntries))
                    phoneBooksQuery = phoneBooksQuery.Include(field);
            }

            return phoneBooksQuery.FirstOrDefault();
        }

        public int UpdatePhoneBook(PhoneBook phoneBook)
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
