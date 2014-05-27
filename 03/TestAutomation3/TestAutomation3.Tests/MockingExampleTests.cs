using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TestAutomation3.Tests
{
    public class User
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }

    public interface IUserService
    {
        User GetByUsername(string username);
        bool IsValidLoginCredentials(string username, string clearTextPassword);
        void Create(User user);
    }
    
    [TestClass]
    public class MockingExampleTests
    {
        private IUserService _userService;

        [TestInitialize]
        public void SetUp()
        {
            _userService = Substitute.For<IUserService>();
        }

        [TestMethod]
        public void Stubbing_is_used_to_setup_what_data_to_return_from_methods()
        {
            var kalle = new User() { Username = "Kalle" };

            // Arrange
            _userService.GetByUsername("Kalle").Returns(kalle);

            // Act
            var actualUser = _userService.GetByUsername("Kalle");

            // Assert
            Assert.AreSame(kalle, actualUser);
        }

        [TestMethod]
        public void Calling_a_stubbed_method_with_the_wrong_arguments_returns_default_value()
        {
            var kalle = new User() { Username = "Kalle" };

            _userService.GetByUsername("Kalle").Returns(kalle);

            var actualUser = _userService.GetByUsername("Another username");

            Assert.IsNull(actualUser);
        }

        [TestMethod]
        public void Mocking_is_used_to_verify_that_methods_with_side_effects_are_called()
        {
            var user = new User();

            _userService.Create(user);

            _userService.Received().Create(user);
        }

        [TestMethod]
        public void Mocking_is_also_used_to_verify_that_methods_with_side_effects_are_NOT_called()
        {
            var user = new User();

            // Nothing to be done here...

            _userService.DidNotReceive().Create(user);
        }

        [TestMethod]
        public void Wild_cards_can_be_used_in_place_of_hard_coded_parameter_values()
        {
            var kalle = new User() { Username = "Kalle" };

            _userService.GetByUsername(Arg.Any<string>()).Returns(kalle);

            var actualUser = _userService.GetByUsername("Some other username");

            Assert.AreSame(kalle, actualUser);
        }

        [TestMethod]
        public void Complex_matchers_can_also_be_used_in_place_of_hard_coded_parameter_values()
        {
            _userService.Create(new User() { Username = "Pelle" });

            _userService.Received().Create(Arg.Is<User>(x => x.Username.Contains("ll")));
        }
        
        [TestMethod]
        public void Matchers_can_be_mixed_with_hard_coded_parameter_values()
        {
            _userService.IsValidLoginCredentials("kalle", Arg.Any<string>()).Returns(true);

            var actualValue = _userService.IsValidLoginCredentials("kalle", "some password");

            Assert.IsTrue(actualValue);
        }
    }
}