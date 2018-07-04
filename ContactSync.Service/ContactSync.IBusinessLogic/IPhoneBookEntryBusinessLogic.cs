using ContactSync.Entities;
using System.Collections.Generic;

namespace ContactSync.IBusinessLogic
{
    public interface IPhoneBookEntryBusinessLogic
    {
        PhoneBookEntry AddPhoneBookEntryToPhoneBook(long phoneBookId, PhoneBookEntry phoneBookEntry);

        PhoneBookEntry GetPhoneBookEntryById(long phoneBookId, long phoneBookEntryId);

        IEnumerable<PhoneBookEntry> SearchPhoneBookEntries(long phoneBookId, string search = "");
    }
}
