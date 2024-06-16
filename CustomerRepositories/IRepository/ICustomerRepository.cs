using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerModels.Models;

namespace CustomerRepositories.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
