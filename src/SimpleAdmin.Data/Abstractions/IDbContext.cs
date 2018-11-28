using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAdmin.Data.Abstractions
{
    public interface IDbContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();
    }
}
