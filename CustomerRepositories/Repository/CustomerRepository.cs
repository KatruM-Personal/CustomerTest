using CustomerModels.Models;
using CustomerRepositories.IRepository;

namespace CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> Customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "Customer A", Email = "ca@example.com", Phone = "1234567890" },
            new Customer { Id = 2, Name = "Customer B", Email = "cb@example.com", Phone = "9876543210" },
            new Customer { Id = 3, Name = "Customer C", Email = "cc@example.com", Phone = "5551234567" }
        };
        private static int customerId = Customers.Count;

        public IEnumerable<Customer> GetAll() => Customers;

        public Customer Get(int id) => Customers.FirstOrDefault(c => c.Id == id);

        public void Add(Customer customer)
        {
            customer.Id = customerId++;
            Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var index = Customers.FindIndex(c => c.Id == customer.Id);
            if (index != -1)
            {
                Customers[index] = customer;
            }
        }

        public void Delete(int id)
        {
            var customer = Get(id);
            if (customer != null)
            {
                Customers.Remove(customer);
            }
        }
    }
}
