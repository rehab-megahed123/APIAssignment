using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.BLL.Repository.Abstraction;
using API.DAL.Models;

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

        public Product GetById(int id)
        {
           Product product= _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
    }
}
