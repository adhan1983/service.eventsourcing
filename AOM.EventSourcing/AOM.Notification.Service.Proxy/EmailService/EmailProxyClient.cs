using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AOM.Notification.Service.Proxy.Helpers.Interfaces;
using AOM.Notification.Service.Proxy.EmailService.Interfaces;

namespace AOM.Notification.Service.Proxy.EmailService
{
    public class EmailProxyClient : IEmailProxyClient
    {
        private readonly IConfigurationEmailProxyClient _configurationEmailProxyClient;
        public EmailProxyClient(IConfigurationEmailProxyClient configurationEmailProxyClient)
            => _configurationEmailProxyClient = configurationEmailProxyClient;

        public Task SendEmail(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();

            return Task.FromResult(0);
        }
        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                var _emailSettings = _configurationEmailProxyClient.GetEmailSettingsProxyClient();

                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, _emailSettings.DisplayName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = "A new client was created - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
