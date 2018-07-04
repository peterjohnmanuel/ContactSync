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

            if (!contactSyncContext.ContactGroups.Any())
            {
                var contactData = new List<ContactGroup>
                {
                    new ContactGroup
                    {
                        Name = "Family",
                        Contacts = new List<Contact>
                        {
                            new Contact
                            {
                                FirstName = "Garth",
                                HomeNumber = "0847694322"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Friends",
                        Contacts = new List<Contact>()
                        {
                            new Contact
                            {
                                FirstName = "Sheldon",
                                HomeNumber = "0694521839"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Work Colleagues",
                        Contacts = new List<Contact>()
                        {
                            new Contact
                            {
                                FirstName = "Jamie",
                                HomeNumber = "0746912384"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Business Contacts",
                        Contacts = new List<Contact>()
                        {
                            new Contact
                            {
                                FirstName = "PG Glass",
                                HomeNumber = "084692135"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Emergancy Contacts",
                        Contacts = new List<Contact>()
                        {
                            new Contact
                            {
                                FirstName = "Fraud Reporting",
                                HomeNumber = "0846912580"
                            }
                        }
                    }
                };

                contactSyncContext.ContactGroups.AddRange(contactData);
            }

            contactSyncContext.SaveChanges();
        }

    }
}
