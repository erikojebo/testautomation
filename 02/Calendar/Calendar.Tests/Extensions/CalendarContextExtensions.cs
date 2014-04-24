using Calendar.DataAccess;

namespace Calendar.Tests.Extensions
{
    public static class CalendarContextExtensions
    {
         public static void DeleteEverything(this CalendarContext context)
         {
             context.Database.ExecuteSqlCommand("DELETE FROM CalendarEntries");
             context.Database.ExecuteSqlCommand("DELETE FROM Persons");
         }
    }
}