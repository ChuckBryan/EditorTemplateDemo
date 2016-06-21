namespace EditorTemplateDemo.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Domain;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }


        private DbContextTransaction _currentTransaction;

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void CloseTransaction()
        {
            CloseTransaction(null);
        }

        public void CloseTransaction(Exception exception)
        {
            try
            {
                if (_currentTransaction != null && exception != null)
                {
                    // todo: log exception
                    _currentTransaction.Rollback();
                    return;
                }

                if (ChangedEntities().Any())
                {
                    SaveChanges();
                }

                _currentTransaction?.Commit();
            }
            catch (Exception)
            {
                if (_currentTransaction?.UnderlyingTransaction.Connection != null)
                {
                    _currentTransaction.Rollback();
                }

                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        private IEnumerable<DbEntityEntry> ChangedEntities()
        {
            return this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added
                                                           || e.State == EntityState.Modified ||
                                                           e.State == EntityState.Deleted);
        }
    }
}