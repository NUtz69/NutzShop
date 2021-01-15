using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        // Internal
        internal DataContext context;
        internal DbSet<T> dbSet;

        // Constructors
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        // IRepository<T>
        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        /* Method */

        // Commit
        public void Commit()
        {
            context.SaveChanges();
        }

        // Delete
        public void Delete(string Id)
        {
            var t = Find(Id);

            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);

        }

        // Find
        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        // Insert
        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        // Update
        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
