using ContactSync.Common;
using ContactSync.Common.ValidationMessages;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using ContactSync.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ContactSync.BusinessLogic
{
    public class ContactBusinessLogic : IContactBusinessLogic
    {

        private readonly IContactGroupRepository contactGroupRepository;

        public ContactBusinessLogic(IContactGroupRepository contactGroupRepository)
        {
            this.contactGroupRepository = contactGroupRepository;
        }

        public Contact AddContactToContactGroup(long phoneBookId, Contact phoneBookEntry)
        {
            var phoneBook = contactGroupRepository.GetContactGroupById(phoneBookId);

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            if (phoneBook.ContactGroups == null)
                phoneBook.ContactGroups = new List<Contact>();

            phoneBook.ContactGroups.Add(phoneBookEntry);

            contactGroupRepository.UpdateContactGroup(phoneBook);

            return phoneBookEntry;
        }

        public Contact GetContactById(long phoneBookId, long phoneBookEntryId)
        {
            var phoneBook = contactGroupRepository.GetContactGroupById(phoneBookId, "PhoneBookEntries");

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            var phoneBookEntry = phoneBook.ContactGroups.FirstOrDefault(x => x.Id == phoneBookEntryId);

            if (phoneBookEntry == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookEntryNotFound);

            return phoneBookEntry;
        }

        public IEnumerable<Contact> SearchContacts(long phoneBookId, string search = "")
        {
            var phoneBook = contactGroupRepository.GetContactGroupById(phoneBookId, "PhoneBookEntries");

            if (phoneBook == null)
                throw new BusinessRuleException(ValidationMessages.PhoneBookNotFound);

            var phoneBookEntries = phoneBook.ContactGroups
                .Where(x => 
                
                    x.Name.ToLower().Contains(search.ToLower())
                    || x.PhoneNumber.ToLower().Contains(search.ToLower())
                );

            return phoneBookEntries;
        }
    }
}
