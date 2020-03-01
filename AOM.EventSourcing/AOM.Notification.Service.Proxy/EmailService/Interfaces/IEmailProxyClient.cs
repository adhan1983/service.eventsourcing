using System.Threading.Tasks;

namespace AOM.Notification.Service.Proxy.EmailService.Interfaces
{
    public interface IEmailProxyClient
    {
        Task SendEmail(string email, string subject, string message);
    }
}
