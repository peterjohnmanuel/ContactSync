using System.Collections.Generic;

namespace ContactSync.Entities
{
    public class PhoneBook
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PhoneBookEntry> PhoneBookEntries { get; set; }

    }
}
