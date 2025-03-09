using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void UpdateProduct(Product product);
        public List<Product> GetByCategory(string category);
        public List<Product> GetAll();
        public void Delete(Product product);
    }
}
