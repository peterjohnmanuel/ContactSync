using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IBusinessLogic
{
    public interface IContactBusinessLogic
    {
        Contact AddContactToContactGroup(long contactGroupId, Contact contact);

        Contact GetContactById(long contactGroupId, long contactId);

        IEnumerable<Contact> SearchContacts(long contactGroupId, string search = "");

        Contact UpdateContactInfo(long contactGroupId, long contactId, Contact contact);
    }
}
