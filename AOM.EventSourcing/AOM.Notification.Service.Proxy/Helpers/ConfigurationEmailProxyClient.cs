using AOM.Notification.Service.Proxy.Contracts;
using AOM.Notification.Service.Proxy.Helpers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace AOM.Notification.Service.Proxy.Helpers
{
    public class ConfigurationEmailProxyClient : IConfigurationEmailProxyClient
    {
        private readonly IConfiguration _configuration;
        public ConfigurationEmailProxyClient(IConfiguration configuration) => _configuration = configuration;
        public EmailSettingsProxyClient GetEmailSettingsProxyClient()
        {
            EmailSettingsProxyClient emailSettingsProxyClient = new EmailSettingsProxyClient();

            var _emailSettingsProxyClientConfig = _configuration.GetSection("EmailSettingsProxyClient");

            emailSettingsProxyClient.PrimaryDomain = _emailSettingsProxyClientConfig.GetSection("PrimaryDomain").Value;
            emailSettingsProxyClient.PrimaryPort = Convert.ToInt32(_emailSettingsProxyClientConfig.GetSection("PrimaryPort").Value);
            emailSettingsProxyClient.UsernameEmail = _emailSettingsProxyClientConfig.GetSection("UsernameEmail").Value;
            emailSettingsProxyClient.DisplayName = _emailSettingsProxyClientConfig.GetSection("DisplayName").Value;
            emailSettingsProxyClient.UsernamePassword = _emailSettingsProxyClientConfig.GetSection("UsernamePassword").Value;
            emailSettingsProxyClient.FromEmail = _emailSettingsProxyClientConfig.GetSection("FromEmail").Value;
            emailSettingsProxyClient.ToEmail = _emailSettingsProxyClientConfig.GetSection("ToEmail").Value;
            emailSettingsProxyClient.CcEmail = _emailSettingsProxyClientConfig.GetSection("CcEmail").Value;            

            return emailSettingsProxyClient;
        }
    }
}
