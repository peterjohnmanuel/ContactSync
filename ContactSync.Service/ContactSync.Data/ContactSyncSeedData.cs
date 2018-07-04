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
                        ContactGroups = new List<Contact>
                        {
                            new Contact
                            {
                                Name = "Garth",
                                PhoneNumber = "0847694322"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Friends",
                        ContactGroups = new List<Contact>()
                        {
                            new Contact
                            {
                                Name = "Sheldon",
                                PhoneNumber = "0694521839"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Work Colleagues",
                        ContactGroups = new List<Contact>()
                        {
                            new Contact
                            {
                                Name = "Jamie",
                                PhoneNumber = "0746912384"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Business Contacts",
                        ContactGroups = new List<Contact>()
                        {
                            new Contact
                            {
                                Name = "PG Glass",
                                PhoneNumber = "084692135"
                            }
                        }
                    },
                    new ContactGroup
                    {
                        Name = "Emergancy Contacts",
                        ContactGroups = new List<Contact>()
                        {
                            new Contact
                            {
                                Name = "Fraud Reporting",
                                PhoneNumber = "0846912580"
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
