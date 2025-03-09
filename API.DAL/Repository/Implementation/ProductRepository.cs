using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.BLL.Repository.Abstraction;
using API.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repository.Implementation
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository( ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var res = _context.Products.ToList();
            return res;
        }

        public List<Product> GetByCategory(string category)
        {
           var prodList= _context.Products.Where(a => a.category == category).ToList();
           return prodList;
        }

        public Product GetById(int id)
        {
           Product product= _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

        }
    }
}
