using System.Collections;
using System.Collections.Generic;

namespace Calendar.Entities
{
    public class Person
    {
        public Person()
        {
            CalendarEntries = new List<CalendarEntry>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<CalendarEntry> CalendarEntries { get; set; }
    }
}