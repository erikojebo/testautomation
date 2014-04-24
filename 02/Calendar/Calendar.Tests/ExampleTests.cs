using System;
using Calendar.DataAccess;
using Calendar.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.Tests
{
    [TestClass]
    public class ExampleTests
    {
        [TestInitialize]
        public void SetUp()
        {
            // Här kan man lägga initialiseringskod som ska köras innan varje test

            // Till exempel skulle man kunna skapa preppa databasen, 
            // genom att rensa och sen skapa upp det data man vill ha för sitt test
            using (var context = new CalendarContext())
            {
                context.DeleteEverything();

                // Skapa ny testdata i databasen här

                context.SaveChanges();
            }
        }

        // Döp testet till ett tydligt påstående, så man förstår syftet med testet
        // T.ex. Booking_a_meeting_in_an_empty_calendar_successfully_adds_the_booking eller
        //       Booking_a_meeting_when_there_is_a_conflicting_meeting_fails
        [TestMethod]
        public void Some_statement_that_should_be_true()
        {
            // Här läggs testkod enligt modellen:

            // 1. Arrange: Sätt upp världen som den behöver vara för att kunna köra testet, t.ex. new:a upp objekt etc)
            // 2. Act:     Gör det som testet ska testa, typ anropa en servicemetod
            // 3. Assert:  Verifiera att det som vi ville skulle hända faktiskt har hänt, t.ex. genom Assert.AreEqual(expected, actual)
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Här kan man lägga uppstädningskod som ska köras efter varje test
        }
    }
}
