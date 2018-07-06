using System.Collections.Generic;

namespace ContactSync.Entities
{
    public class ContactGroup
    {
        public ContactGroup()
        {
            Contacts = new List<Contact>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
