using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Models;

namespace API.BLL.Repository.Abstraction
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public Product GetById(int id);

    }
}
