using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public bool HasSchedulingConflict(CalendarEntry entry)
        {
            return CalendarEntries.Any(x =>
                        x.StartDate >= entry.StartDate && x.StartDate <= entry.EndDate ||
                        x.EndDate >= entry.StartDate && x.EndDate <= entry.EndDate);
        }
    }
}