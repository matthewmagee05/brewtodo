using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private IList<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer(1, "KinetEco"));
            _customers.Add(new Customer(2, "Pixelford Photography"));
            _customers.Add(new Customer(3, "Topsy Turvy"));
            _customers.Add(new Customer(4, "Leaf & Mortar"));
        }
        public Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }

        public Customer GetCustomerById(int id)
        {
            return GetCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(_customers.Single(o => Equals(o.Id, id)));
        }
    }

    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomerAsync();
    }
}