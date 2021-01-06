﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using NutzShop.Core.Models;

namespace NutzShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        // Vars
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        // Constructors
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        /* Method */

        // Commit
        public void Commit()
        {
            cache["products"] = products;
        }

        // Insert
        public void Insert(Product p)
        {
            products.Add(p);
        }

        // Update
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product no found !");
            }
        }

        // Find
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product no found !");
            }
        }

        // List product
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        // Delete
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product no found !");
            }
        }
    }
}
