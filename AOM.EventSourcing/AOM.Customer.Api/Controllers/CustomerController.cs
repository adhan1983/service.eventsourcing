using AOM.Customer.Domain.Events;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _domain = AOM.Customer.Domain.Model;

namespace AOM.Customer.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<_domain.Customer>>> Get()
        {
            var customers = await this.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] _domain.Customer customer)
        {

            customer.CreateNewCustomer();

            using (var bus = RabbitHutch.CreateBus(Environment.GetEnvironmentVariable("RABBITCONNECTION")))
            {
                bus.Publish(new CustomerCreatedEvent(customer.Id, customer.Email));
            }
            
            return Ok();
        }
        private async Task<List<_domain.Customer>> GetCustomers() 
        {
            List<_domain.Customer> customers = new List<_domain.Customer>();

            customers.Add(new _domain.Customer { });

            customers.Add(new _domain.Customer { });

            return await Task.FromResult(customers);
        }

    }
}