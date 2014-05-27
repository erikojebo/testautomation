using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using studiecirkel_1;

namespace Tests
{
    [TestClass]
    public class PersonTests
    {
        private Person _person;

        [TestInitialize]
        public void SetUp()
        {
            _person = new Person();            
        }

        [TestMethod]
        public void Person_without_first_name_is_invalid()
        {
            _person.FirstName = null;

            var errors = _person.Validate();

            Assert.IsTrue(errors.Count() >= 1);
        }
    }
}