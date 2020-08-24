using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContextOptions<capacitacion> options)
        {
            this.context = new capacitacion(options);
        }

        public DbSet<T> GetDbSet<T>()
            where T : class
        {
            return context.Set<T>();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public DbContext GetDbContext()
        {
            return context;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

    }
}
