using CRUDContacts.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace CRUDContacts.Data
{
    public class CRUDContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public CRUDContactsContext(DbContextOptions<CRUDContactsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
