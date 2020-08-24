using Microsoft.EntityFrameworkCore;
using System;

namespace Core.EF
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext GetDbContext();
        int SaveChanges();
    }
}
