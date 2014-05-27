using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TestAutomation3.Controllers;
using TestAutomation3.Models;
using TestAutomation3.Services;

namespace TestAutomation3.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        private AccountController _controller;
        private IEmailService _mockEmailService;

        [TestInitialize]
        public void SetUp()
        {
            _mockEmailService = Substitute.For<IEmailService>();

            _controller = new AccountController(_mockEmailService);
        }

        [TestMethod]
        public void Verification_email_is_sent_when_registering_a_new_account()
        {
            var model = new RegistrationModel
            {
                Email = "kalle@mail.com",
                CustomerNumber = "123456"
            };

            _controller.Register(model);

            _mockEmailService.Received().Send(Arg.Any<string>(), Arg.Any<string>(), "kalle@mail.com");
        }

        [TestMethod]
        public void No_email_is_sent_when_registering_a_new_account_with_an_invalid_email_address()
        {
            _controller.ViewData.ModelState.AddModelError("Email", "Invalid email");

            var model = new RegistrationModel
            {
                Email = "invalid email",
                CustomerNumber = "123456"
            };

            _controller.Register(model);

            _mockEmailService.DidNotReceive().Send(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
