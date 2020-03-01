using Microsoft.Extensions.Configuration;
using System;

namespace AOM.Notification.Service.Proxy.Contracts
{
    public class EmailSettingsProxyClient
    {
        
        public String PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public String UsernameEmail { get; set; }
        public String DisplayName { get; set; }
        public String UsernamePassword { get; set; }
        public String FromEmail { get; set; }
        public String ToEmail { get; set; }
        public String CcEmail { get; set; }       

    }
}
