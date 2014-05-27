using System.Net.Mail;

namespace TestAutomation3.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string subject, string body, string recipient)
        {
            throw new SmtpException("Coult not send mail");
        }
    }
}