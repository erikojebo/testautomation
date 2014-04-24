using System;

namespace Calendar.Entities
{
    public class CalendarEntry
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}