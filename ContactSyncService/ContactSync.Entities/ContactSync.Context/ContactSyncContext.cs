﻿using ContactSync.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSync.Context
{
    public class ContactSyncContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<PhoneBookEntry> Entries { get; set; }

        public ContactSyncContext(DbContextOptions<ContactSyncContext> options) : base(options)
        {
        }
    }
}
