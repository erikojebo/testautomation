using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TestAutomation3.Controllers;
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
            
        }
    }
}
