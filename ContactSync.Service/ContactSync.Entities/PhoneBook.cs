using System.Collections.Generic;

namespace ContactSync.Entities
{
    public class PhoneBook
    {
        public PhoneBook()
        {
            PhoneBookEntries = new List<PhoneBookEntry>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<PhoneBookEntry> PhoneBookEntries { get; set; }
    }
}
