namespace ContactSync.Entities
{
    public class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ContactGroup ContactGroup { get; set; }
    }
}
