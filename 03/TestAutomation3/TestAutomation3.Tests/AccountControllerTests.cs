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

        // Uppgift: 
        // 1. Skriv ett test som verifierar att ett epostmeddelande skickas till rätt adress
        //    när man anropar _controller.Register med en modell som validerar.
        //    Dvs. att emailService.Send anropas med e-postadressen från modellen.
        //
        // 2. Skriv ett test som verifierar att inget mail skickas om det finns valideringsfel
        //    i modellen.
        //
        //    För att låtsas som att MVC:s validering gett ett valideringsfel kan man göra så här
        //    _controller.ViewData.ModelState.AddModelError("Email", "Invalid email");
        //    Så om man lägger den raden överst i sitt test kommer controllern sen tro att det finns
        //    valideringsfel
        //
        // BONUS:
        // 3. Skriv ett till test som det i uppgift 1, men skriv en egen mock-implementation av IEmailService
        //    och använd den istället för NSubstitute-objektet.
    }
}
