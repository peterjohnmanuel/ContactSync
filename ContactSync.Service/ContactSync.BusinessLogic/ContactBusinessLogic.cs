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

            IEnumerable<Contact> contacts;

            if (!string.IsNullOrEmpty(search))
            {
                contacts = contactGroups.Contacts
                .Where(x =>

                    x.FirstName.ToLower().Contains(search.ToLower())
                    || x.HomeNumber.ToLower().Contains(search.ToLower())
                );
            }
            else
                contacts = contactGroups.Contacts;

            return contacts;
        }

        public Contact UpdateContactInfo(long contactGroupId, long contactId, Contact contact)
        {
            var contactGroup = contactGroupRepository.GetContactGroupById(contactGroupId, "Contacts");

            if (contactGroup == null)
                throw new BusinessRuleException(ValidationMessages.ContactGroupNotFound);

            var existingContact = contactGroup.Contacts.FirstOrDefault(x => x.Id == contactId);

            if (existingContact == null)
                throw new BusinessRuleException(ValidationMessages.ContactNotFound);

            existingContact.FirstName = !string.IsNullOrEmpty(contact.FirstName) ? contact.FirstName : existingContact.FirstName;
            existingContact.LastName = !string.IsNullOrEmpty(contact.LastName) ? contact.LastName : existingContact.LastName;
            existingContact.HomeNumber = !string.IsNullOrEmpty(contact.HomeNumber) ? contact.HomeNumber : existingContact.HomeNumber;
            existingContact.MobileNumber = !string.IsNullOrEmpty(contact.MobileNumber) ? contact.MobileNumber : existingContact.MobileNumber;
            existingContact.Email = !string.IsNullOrEmpty(contact.Email) ? contact.Email : existingContact.Email;

            contactGroupRepository.UpdateContactGroup(contactGroup);

            return existingContact;
        }
    }
}
