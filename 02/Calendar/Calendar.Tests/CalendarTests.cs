using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.DataAccess;
using Calendar.DTOs;
using Calendar.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.Tests
{
    [TestClass]
    public class CalendarTests
    {
        private Person _person;
        private CalendarService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new CalendarService();

            using (var context = new CalendarContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM CalendarEntries");
                context.Database.ExecuteSqlCommand("DELETE FROM Persons");

                _person = new Person
                {
                    FirstName = "Kalle",
                    LastName = "Persson"
                };

                context.Set<Person>().Add(_person);

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Booking_a_meeting_without_conflicts_successfully_adds_the_meeting_to_the_calendar()
        {
            // Arrange
            var meeting = new CalendarEntryDTO
            {
                StartDate = new DateTime(2015, 1, 1, 10, 30, 0),
                EndDate = new DateTime(2015, 1, 1, 10, 45, 0),
                Title = "Daily standup",
                PersonId = _person.Id
            };

            // Act
            var response = _service.Book(meeting);

            // Assert
            using (var context = new CalendarContext())
            {
                var actualPerson = context.Set<Person>().Single(x => x.Id == _person.Id);

                Assert.IsTrue(response.WasSuccessful);
                Assert.AreEqual(1, actualPerson.CalendarEntries.Count);

                var actualCalendarEntry = actualPerson.CalendarEntries.First();

                Assert.AreEqual(meeting.StartDate, actualCalendarEntry.StartDate);
                Assert.AreEqual(meeting.EndDate, actualCalendarEntry.EndDate);
                Assert.AreEqual(meeting.Title, actualCalendarEntry.Title);
            }
        }
    }
}
