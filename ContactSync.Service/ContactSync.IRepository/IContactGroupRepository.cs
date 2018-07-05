using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IRepository
{
    public interface IContactGroupRepository
    {
        IEnumerable<ContactGroup> GetAllContactGroups();

        ContactGroup GetContactGroupById(long id, string includedFields = "");

        int AddContactGroup(ContactGroup contactGroup);

        int UpdateContactGroup(ContactGroup contactGroup);
    }
}
