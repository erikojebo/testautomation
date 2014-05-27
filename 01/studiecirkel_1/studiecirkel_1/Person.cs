using System.Collections.Generic;

namespace studiecirkel_1
{
    public class Person
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string TelephoneNumber { get; set; } 

        public IEnumerable<string> Validate()
        {
            var errors = new List<string>();

            // Do something here...

            return errors;
        }
    }
}