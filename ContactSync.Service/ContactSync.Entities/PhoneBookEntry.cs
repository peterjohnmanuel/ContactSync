namespace ContactSync.Entities
{
    public class PhoneBookEntry
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneBook PhoneBook { get; set; }
    }
}
