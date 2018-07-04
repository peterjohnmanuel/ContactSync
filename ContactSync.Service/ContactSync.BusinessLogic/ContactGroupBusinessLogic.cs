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
    }
}
