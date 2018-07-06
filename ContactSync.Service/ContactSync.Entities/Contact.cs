namespace ContactSync.Entities
{
    public class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public ContactGroup ContactGroup { get; set; }
    }
}
