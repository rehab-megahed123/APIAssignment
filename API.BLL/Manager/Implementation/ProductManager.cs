﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.BLL.Manager.Abstraction;
using API.BLL.Repository.Abstraction;
using API.DAL.Models;
using API.DAL.Repository.Implementation;

namespace API.BLL.Manager.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository _productRepository)
        {
            productRepository = _productRepository;  
        }
        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);

        }

        public List<Product> GetAll()
        {
            var res=productRepository.GetAll();
            return res;
        }

        public List<Product> GetByCategory(string category)
        {
           var res= productRepository.GetByCategory(category);
           return res;
        }

        public Product GetById(int id)
        {
            Product product=productRepository.GetById(id);
            return product;
        }

        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
