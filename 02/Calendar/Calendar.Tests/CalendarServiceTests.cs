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
    public class CalendarServiceTests
    {
        private CalendarService _service;
        private Person _person;

        [TestInitialize]
        public void SetUp()
        {
            _service = new CalendarService();

            _person = new Person
            {
                FirstName = "Kalle",
                LastName = "Persson"
            };

            using (var context = new CalendarContext())
            {
                context.DeleteEverything();

                context.Persons.Add(_person);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Booking_a_meeting_in_an_empty_calendar_adds_a_meeting_for_the_specified_time()
        {
            var booking = new CalendarEntryDTO
            {
                StartDate = new DateTime(2014, 4, 25, 10, 0, 0),
                EndDate = new DateTime(2014, 4, 25, 10, 30, 0),
                Title = "Daily stand up",
                PersonId = _person.Id
            };

            var result = _service.Book(booking);

            Assert.IsTrue(result.WasSuccessful);

            using (var context = new CalendarContext())
            {
                var actualPerson = context.Persons.Single(x => x.Id == _person.Id);

                Assert.AreEqual(1, actualPerson.CalendarEntries.Count);

                var actualBooking = actualPerson.CalendarEntries.Single();

                Assert.AreEqual(new DateTime(2014, 4, 25, 10, 0, 0), actualBooking.StartDate);
                Assert.AreEqual(new DateTime(2014, 4, 25, 10, 30, 0), actualBooking.EndDate);
                Assert.AreEqual("Daily stand up", actualBooking.Title);
            }
        }

        [TestMethod]
        public void Booking_a_meeting_when_there_is_a_scheduling_conflict_leaves_the_calendar_unchanged()
        {
            var existingMeeting = new CalendarEntry()
            {
                StartDate = new DateTime(2014, 4, 25, 9, 45, 0),
                EndDate = new DateTime(2014, 4, 25, 10, 15, 0),
                Title = "Morning meeting",
                PersonId = _person.Id
            };

            using (var context = new CalendarContext())
            {
                context.CalendarEntries.Add(existingMeeting);
                context.SaveChanges();
            }

            var booking = new CalendarEntryDTO
            {
                StartDate = new DateTime(2014, 4, 25, 10, 0, 0),
                EndDate = new DateTime(2014, 4, 25, 10, 30, 0),
                Title = "Daily stand up",
                PersonId = _person.Id
            };

            var result = _service.Book(booking);

            Assert.IsFalse(result.WasSuccessful);

            using (var context = new CalendarContext())
            {
                var actualPerson = context.Persons.Single(x => x.Id == _person.Id);

                Assert.AreEqual(1, actualPerson.CalendarEntries.Count);

                var actualBooking = actualPerson.CalendarEntries.Single();

                Assert.AreEqual(new DateTime(2014, 4, 25, 9, 45, 0), actualBooking.StartDate);
                Assert.AreEqual(new DateTime(2014, 4, 25, 10, 15, 0), actualBooking.EndDate);
                Assert.AreEqual("Morning meeting", actualBooking.Title);
            }
        }
    }
}