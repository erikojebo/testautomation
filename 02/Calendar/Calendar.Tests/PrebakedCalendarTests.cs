using System;
using System.Linq;
using Calendar.DataAccess;
using Calendar.DTOs;
using Calendar.Entities;
using Calendar.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.Tests
{
    [TestClass]
    public class PrebakedCalendarTests
    {
        private Person _person;
        private CalendarService _service;

        [TestInitialize]
        public void SetUp()
        {
            _service = new CalendarService();

            using (var context = new CalendarContext())
            {
                context.DeleteEverything();

                _person = new Person
                {
                    FirstName = "Kalle",
                    LastName = "Persson"
                };

                // Lägg till en person i databasen, så att vi har någon att boka möten för.
                // När personen sparas i databasen får den ett id av SQL Server, och det är det
                // id:t som vi behöver komma ihåg till dess att vi ska boka möten.
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
                PersonId = _person.Id // Här använder vi det id som vi fick av SQL Server
            };

            // Act
            var response = _service.Book(meeting);

            // Assert
            using (var context = new CalendarContext())
            {
                // Ladda upp personen igen, så att vi får med all ny data som kommit till efter anropet
                // till WCF-tjänsten
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
