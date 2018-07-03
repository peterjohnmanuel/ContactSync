using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IBusinessLogic
{
    public interface IPhoneBookBusinessLogic
    {
        IEnumerable<PhoneBook> GetAllPhoneBooks();
    }
}
