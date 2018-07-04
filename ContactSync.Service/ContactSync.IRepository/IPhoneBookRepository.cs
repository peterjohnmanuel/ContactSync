using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IRepository
{
    public interface IPhoneBookRepository
    {
        IEnumerable<PhoneBook> GetAllPhoneBooks();

        PhoneBook GetPhoneBookById(long id, string includedFields = "");

        int AddNewPhoneBook(PhoneBook phoneBook);

        int UpdatePhoneBook(PhoneBook phoneBook);
    }
}
