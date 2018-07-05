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
                                LastName = "Black",
                                HomeNumber = "847694322",
                                MobileNumber = "749498520",
                                Email = "GarthBlack@gmail.com"
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
                                LastName = "Cooper",
                                HomeNumber = "694521839",
                                MobileNumber = "749498520",
                                Email = "SheldonCooper@yahoo.com"
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
                                LastName = "Arendse",
                                HomeNumber = "746912384",
                                MobileNumber = "749498520",
                                Email = "JamieLot@aol.com"
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
                                HomeNumber = "84692135",
                                Email = "pgglass@pgglass.com"
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
                                HomeNumber = "846912580",
                                Email = "fraudreporters@ct.gov"
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
