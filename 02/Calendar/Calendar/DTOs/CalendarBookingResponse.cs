using System.Runtime.Serialization;

namespace Calendar.DTOs
{
    [DataContract]
    public class CalendarBookingResponse
    {
        public bool WasSuccessful { get; set; }
    }
}