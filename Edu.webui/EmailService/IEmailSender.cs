using System.Threading.Tasks;

namespace Edu.webui.EmailService
{
    public interface IEmailSender
    {
         Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}