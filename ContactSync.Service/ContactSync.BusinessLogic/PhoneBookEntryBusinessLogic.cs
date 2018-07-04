using ContactSync.Common;
using ContactSync.Common.ValidationMessages;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using ContactSync.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ContactSync.BusinessLogic
{
    public class PhoneBookEntryBusinessLogic : IPhoneBookEntryBusinessLogic
    {

        private readonly IPhoneBookRepository phoneBookRepository;

        public PhoneBookEntryBusinessLogic(IPhoneBookRepository phoneBookRepository)
        {
            this.phoneBookRepository = phoneBookRepository;
        }

        public PhoneBookEntry AddPhoneBookEntryToPhoneBook(long phoneBookId, PhoneBookEntry phoneBookEntry)
        {
            var phoneBook = phoneBookRepository.GetPhoneBookById(phoneBookId);

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            if (phoneBook.PhoneBookEntries == null)
                phoneBook.PhoneBookEntries = new List<PhoneBookEntry>();

            phoneBook.PhoneBookEntries.Add(phoneBookEntry);

            phoneBookRepository.UpdatePhoneBook(phoneBook);

            return phoneBookEntry;
        }

        public PhoneBookEntry GetPhoneBookEntryById(long phoneBookId, long phoneBookEntryId)
        {
            var phoneBook = phoneBookRepository.GetPhoneBookById(phoneBookId, "PhoneBookEntries");

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            var phoneBookEntry = phoneBook.PhoneBookEntries.FirstOrDefault(x => x.Id == phoneBookEntryId);

            if (phoneBookEntry == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookEntryNotFound);

            return phoneBookEntry;
        }

        public IEnumerable<PhoneBookEntry> SearchPhoneBookEntries(long phoneBookId, string search = "")
        {
            var phoneBook = phoneBookRepository.GetPhoneBookById(phoneBookId, "PhoneBookEntries");

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            var phoneBookEntries = phoneBook.PhoneBookEntries
                .Where(x => 
                
                    x.Name.ToLower().Contains(search.ToLower())
                    || x.PhoneNumber.ToLower().Contains(search.ToLower())
                );

            return phoneBookEntries;
        }
    }
}
