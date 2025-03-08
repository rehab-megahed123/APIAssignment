using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Models;

namespace API.BLL.Manager.Abstraction
{
    public interface IProductManager
    {
        public void AddProduct(Product product);
        public Product GetById(int id);
    }
}
