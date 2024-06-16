using CustomerModels.Models;
using CustomerRepositories.IRepository;

namespace CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> Customers = new List<Customer>();
        private static int nextId = 1;

        public IEnumerable<Customer> GetAll() => Customers;

        public Customer Get(int id) => Customers.FirstOrDefault(c => c.Id == id);

        public void Add(Customer customer)
        {
            customer.Id = nextId++;
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
