using ContactSync.Context;
using ContactSync.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSync.Data
{
    public class ContactSyncSeedData
    {
        private readonly ContactSyncContext contactSyncContext;

        public ContactSyncSeedData(ContactSyncContext contactSyncContext)
        {
            this.contactSyncContext = contactSyncContext;
        }

        public void Seed()
        {
            contactSyncContext.Database.EnsureCreated();

            if (!contactSyncContext.PhoneBooks.Any())
            {
                var phonebookData = new List<PhoneBook>
                {
                    new PhoneBook
                    {
                        Name = "Family",
                        PhoneBookEntries = new List<PhoneBookEntry>
                        {
                            new PhoneBookEntry
                            {
                                Name = "Garth",
                                PhoneNumber = "0847694322"
                            }
                        }
                    },
                    new PhoneBook
                    {
                        Name = "Friends",
                        PhoneBookEntries = new List<PhoneBookEntry>()
                        {
                            new PhoneBookEntry
                            {
                                Name = "Sheldon",
                                PhoneNumber = "0694521839"
                            }
                        }
                    },
                    new PhoneBook
                    {
                        Name = "Work Colleagues",
                        PhoneBookEntries = new List<PhoneBookEntry>()
                        {
                            new PhoneBookEntry
                            {
                                Name = "Jamie",
                                PhoneNumber = "0746912384"
                            }
                        }
                    },
                    new PhoneBook
                    {
                        Name = "Business Contacts",
                        PhoneBookEntries = new List<PhoneBookEntry>()
                        {
                            new PhoneBookEntry
                            {
                                Name = "PG Glass",
                                PhoneNumber = "084692135"
                            }
                        }
                    },
                    new PhoneBook
                    {
                        Name = "Emergancy Contacts",
                        PhoneBookEntries = new List<PhoneBookEntry>()
                        {
                            new PhoneBookEntry
                            {
                                Name = "Fraud Reporting",
                                PhoneNumber = "0846912580"
                            }
                        }
                    }
                };

                contactSyncContext.PhoneBooks.AddRange(phonebookData);
            }

            contactSyncContext.SaveChanges();
        }

    }
}
