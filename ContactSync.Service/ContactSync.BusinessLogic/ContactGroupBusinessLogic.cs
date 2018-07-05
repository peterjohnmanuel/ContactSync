using ContactSync.Common;
using ContactSync.Common.ValidationMessages;
using ContactSync.Entities;
using ContactSync.IBusinessLogic;
using ContactSync.IRepository;
using System.Collections.Generic;

namespace ContactSync.BusinessLogic
{
    public class ContactGroupBusinessLogic : IContactGroupBusinessLogic
    {
        private readonly IContactGroupRepository contactGroupRepository;

        public ContactGroupBusinessLogic(IContactGroupRepository contactGroupRepository)
        {
            this.contactGroupRepository = contactGroupRepository;
        }

        public IEnumerable<ContactGroup> GetAllContactGroups()
        {
            return contactGroupRepository.GetAllContactGroups();
        }

        public int UpdateContactGroup(long contactGroupId, ContactGroup contactGroup)
        {
            var contactGroupExisting = contactGroupRepository.GetContactGroupById(contactGroupId);

            if (contactGroupExisting == null)
                throw new BusinessRuleException(ValidationMessages.ContactGroupNotFound);

            contactGroup.Id = contactGroupId;

            contactGroupExisting.Name = contactGroup.Name;

            return contactGroupRepository.UpdateContactGroup(contactGroupExisting);
        }
    }
}
