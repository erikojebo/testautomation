using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Calendar.DTOs;

namespace Calendar
{
    [ServiceContract]
    public interface ICalendarService
    {
        [OperationContract]
        CalendarBookingResponse Book(CalendarEntryDTO entry);
    }
}
