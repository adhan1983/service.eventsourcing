using AOM.Notification.Service.Proxy.Contracts;

namespace AOM.Notification.Service.Proxy.Helpers.Interfaces
{
    public interface IConfigurationEmailProxyClient
    {
        EmailSettingsProxyClient GetEmailSettingsProxyClient();
    }
}
