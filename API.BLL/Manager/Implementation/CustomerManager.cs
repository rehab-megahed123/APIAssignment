using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.BLL.Manager.Abstraction;
using API.DAL.Models;
using API.DAL.Repository.Abstraction;
using API.DAL.Repository.Implementation;

namespace API.BLL.Manager.Implementation
{
    
    

    
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void AddCustomer(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customerRepository.DeleteCustomer(customer);
        }

        public Customer GetById(int id)
        {
            var customer= customerRepository.GetById(id);
            return customer;
        }
    }
}
