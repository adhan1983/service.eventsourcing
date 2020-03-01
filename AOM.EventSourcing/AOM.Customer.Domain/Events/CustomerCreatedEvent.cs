namespace AOM.Customer.Domain.Events
{
    public class CustomerCreatedEvent
    {
        public CustomerCreatedEvent(int customerId, string email) 
        {
            CustomerId = customerId;
            Email = email;
        }

        public int CustomerId { get; set; }
        public string Email { get; set; }
    }
}
