using AOM.Notification.Service.Proxy.EmailService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AOM.Notification.Service.API.Controllers
{
    [ApiController]
    [Route("api/v1/sendingemail")]    
    public class CustomerNotificationController : ControllerBase
    {
        private readonly ILogger<CustomerNotificationController> _logger;
        private readonly IEmailProxyClient _proxyClient;

        public CustomerNotificationController(ILogger<CustomerNotificationController> logger, IEmailProxyClient proxyClient)
        {
            _logger = logger;
            _proxyClient = proxyClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _proxyClient.SendEmail("adhan.maldonado@yahoo.com.br", "Teste", "Teste Mensagem");

            return Ok("Email enviado com sucesso");
        }
    }
}