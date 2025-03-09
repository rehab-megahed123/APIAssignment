using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Models;
using API.DAL.Repository.Abstraction;

namespace API.DAL.Repository.Implementation
{
    

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer GetById(int id)
        {
           var customer= _context.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }
    }
}
