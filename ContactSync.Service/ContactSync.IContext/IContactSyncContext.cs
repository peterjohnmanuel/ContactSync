using ContactSync.Entities;
using System.Linq;

namespace ContactSync.IContext
{
    public interface IContactSyncContext
    {
        IQueryable<PhoneBook> PhoneBooks { get; }

        IQueryable<PhoneBookEntry> PhoneBookEntries { get; }

    }
}
