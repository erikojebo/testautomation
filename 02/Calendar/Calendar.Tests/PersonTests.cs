using System;
using Calendar.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_with_an_empty_calendar_does_not_have_a_scheduling_conflict_with_a_new_meeting()
        {
            var person = new Person();

            var hasConflict = person.HasSchedulingConflict(new CalendarEntry()
            {
                StartDate = new DateTime(2014, 4, 25, 10, 0, 0),
                EndDate = new DateTime(2014, 4, 25, 10, 30, 0)
            });

            Assert.IsFalse(hasConflict);
        }
    }
}