using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using ContactSync.IRepository;
using System.Collections.Generic;

namespace ContactSync.BusinessLogic
{
    public class PhoneBookBusinessLogic : IPhoneBookBusinessLogic
    {
        private readonly IPhoneBookRepository phoneBookRepository;

        public PhoneBookBusinessLogic(IPhoneBookRepository phoneBookRepository)
        {
            this.phoneBookRepository = phoneBookRepository;
        }

        public IEnumerable<PhoneBook> GetAllPhoneBooks()
        {
            return phoneBookRepository.GetAllPhoneBooks();
        }
    }
}
