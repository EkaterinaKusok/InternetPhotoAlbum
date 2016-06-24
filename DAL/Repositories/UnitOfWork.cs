using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DAL.Interfacies.Repository;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Console.WriteLine(ex.EntityValidationErrors.ToString());
                    throw new DbEntityValidationException("",ex);
                }
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}