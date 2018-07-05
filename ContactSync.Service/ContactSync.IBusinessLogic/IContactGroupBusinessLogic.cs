using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IBusinessLogic
{
    public interface IContactGroupBusinessLogic
    {
        IEnumerable<ContactGroup> GetAllContactGroups();

        int UpdateContactGroup(long contactGroupId, ContactGroup contactGroup);
    }
}
