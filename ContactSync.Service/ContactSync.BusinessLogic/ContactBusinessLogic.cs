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

        public Contact AddContactToContactGroup(long contactGroupId, Contact phoneBookEntry)
        {
            var contactGroup = contactGroupRepository.GetContactGroupById(contactGroupId);

            if (contactGroup == null)
                throw new BusinessRuleException(ValidationMessages.ContactGroupNotFound);

            if (contactGroup.Contacts == null)
                contactGroup.Contacts = new List<Contact>();

            contactGroup.Contacts.Add(phoneBookEntry);

            contactGroupRepository.UpdateContactGroup(contactGroup);

            return phoneBookEntry;
        }

        public Contact GetContactById(long contactGroupId, long contactId)
        {
            var contactGroup = contactGroupRepository.GetContactGroupById(contactGroupId, "Contacts");

            if (contactGroup == null)
                throw new BusinessRuleException(ValidationMessages.ContactGroupNotFound);

            var contact = contactGroup.Contacts.FirstOrDefault(x => x.Id == contactId);

            if (contact == null)
                throw new BusinessRuleException(ValidationMessages.ContactNotFound);

            return contact;
        }

        public IEnumerable<Contact> SearchContacts(long contactGroupId, string search = "")
        {
            var contactGroups = contactGroupRepository.GetContactGroupById(contactGroupId, "Contacts");

            if (contactGroups == null)
                throw new BusinessRuleException(ValidationMessages.ContactGroupNotFound);

            var contacts = contactGroups.Contacts
                .Where(x => 
                
                    x.Name.ToLower().Contains(search.ToLower())
                    || x.PhoneNumber.ToLower().Contains(search.ToLower())
                );

            return contacts;
        }
    }
}
