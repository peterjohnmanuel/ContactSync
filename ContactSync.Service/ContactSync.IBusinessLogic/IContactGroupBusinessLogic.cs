using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IBusinessLogic
{
    public interface IContactGroupBusinessLogic
    {
        IEnumerable<ContactGroup> GetAllContactGroups();

        ContactGroup GetContactGroupById(long contactGroupId);

        int UpdateContactGroup(long contactGroupId, ContactGroup contactGroup);
    }
}
