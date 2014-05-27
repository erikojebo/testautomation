using System.Collections.Generic;

namespace TestAutomation3.Services
{
    public interface IEmailService
    {
        void Send(string subject, string body, string recipient);
    }
}