using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IRepository
{
    public interface IContactGroupRepository
    {
        IEnumerable<ContactGroup> GetAllContactGroups();

        ContactGroup GetContactGroupById(long id, string includedFields = "");

        int AddContactGroup(ContactGroup phoneBook);

        int UpdateContactGroup(ContactGroup phoneBook);
    }
}
