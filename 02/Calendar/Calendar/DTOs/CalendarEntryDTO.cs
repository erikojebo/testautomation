using System;
using System.Runtime.Serialization;

namespace Calendar.DTOs
{
    [DataContract]
    public class CalendarEntryDTO
    {
        [DataMember(IsRequired = true)]
        public string Title { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public int PersonId { get; set; }
    }
}