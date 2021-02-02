using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.WebUI.Tests.Mocks
{
    public class MockContext<T> : IRepository<T> where T: BaseEntity
    {
        // Var
        List<T> items;
        string className;

        // Constructors
        public MockContext()
        {
            items = new List<T>();
        }

        /* Method */

        // Commit
        public void Commit()
        {
            return;
        }

        // Insert
        public void Insert(T t)
        {
            items.Add(t);
        }

        // Update
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not found !");
            }
        }

        // Find
        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + "Not found !");
            }
        }

        // List product or productCategory
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        // Delete
        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);
            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + "Not found !");
            }
        }
    }
}
