using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Calendar.Entities;

namespace Calendar.DataAccess
{
    public class CalendarContext : DbContext
    {
        public CalendarContext() : base("name=CalendarTest")
        {
            
        }

        public DbSet<Person> Persons
        {
            get { return Set<Person>(); }
        }

        public DbSet<CalendarEntry> CalendarEntries
        {
            get { return Set<CalendarEntry>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Persons")
                .HasMany(x => x.CalendarEntries)
                .WithRequired()
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<CalendarEntry>().ToTable("CalendarEntries");
        }
    }
}
