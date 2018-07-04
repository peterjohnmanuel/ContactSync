using System.Collections.Generic;

namespace ContactSync.Dto
{
    public class PhoneBookDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<PhoneBookEntryDto> PhoneBookEntries { get; set; }
    }
}
