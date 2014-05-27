using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAutomation3.Models;
using TestAutomation3.Services;

namespace TestAutomation3.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmailService _emailService;

        public AccountController() : this(new EmailService())
        {
        }

        public AccountController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            _emailService.Send(
                "Verify email address",
                "Hello, please verify your email address using <a href='http://www.somefake.url'>this link</a>",
                model.Email);

            return RedirectToAction("RegisterConfirmation");
        }

        public ActionResult VerifyEmail()
        {
            throw new NotImplementedException();
        }

        public ActionResult RegisterConfirmation()
        {
            return View();
        }
    }
}
