namespace AOM.Customer.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public void CreateNewCustomer() =>this.Id = 1;
        
    }
}
