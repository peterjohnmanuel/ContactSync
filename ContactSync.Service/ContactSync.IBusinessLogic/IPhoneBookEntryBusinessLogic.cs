using ContactSync.Entities;

namespace ContactSync.IBusinessLogic
{
    public interface IPhoneBookEntryBusinessLogic
    {
        PhoneBookEntry AddPhoneBookEntryToPhoneBook(long phoneBookId, PhoneBookEntry phoneBookEntry);

        PhoneBookEntry GetPhoneBookEntryById(long phoneBookId, long phoneBookEntryId);
    }
}
