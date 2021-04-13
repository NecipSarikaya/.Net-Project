using System.Threading.Tasks;

namespace webapi.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email,string subject,string htmlMessage);
    }
}