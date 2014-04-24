using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Calendar.DataAccess;
using Calendar.DTOs;
using Calendar.Entities;

namespace Calendar
{
    public class CalendarService : ICalendarService
    {
        public CalendarBookingResponse Book(CalendarEntryDTO entry)
        {
            try
            {
                using (var context = new CalendarContext())
                {
                    var person = context.Set<Person>().Single(x => x.Id == entry.PersonId);

                    var hasConflictingEntry = person.CalendarEntries.Any(x =>
                        x.StartDate >= entry.StartDate && x.StartDate <= entry.EndDate ||
                        x.EndDate >= entry.StartDate && x.EndDate <= entry.EndDate);

                    if (hasConflictingEntry)
                    {
                        return new CalendarBookingResponse() { WasSuccessful = false };
                    }

                    var calendarEntry = new CalendarEntry
                    {
                        StartDate = entry.StartDate,
                        EndDate = entry.EndDate,
                        Title = entry.Title
                    };

                    person.CalendarEntries.Add(calendarEntry);

                    context.SaveChanges();

                    return new CalendarBookingResponse() { WasSuccessful = true };
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
