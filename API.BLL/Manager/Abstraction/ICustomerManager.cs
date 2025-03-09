using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Models;

namespace API.BLL.Manager.Abstraction
{
    public interface ICustomerManager
    {
        public void AddCustomer(Customer customer);
        public Customer GetById(int id);
        public void DeleteCustomer(Customer customer);
    }
}
