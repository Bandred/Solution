using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public interface IDBContext
    {
        DbSet<OwnerEntity> Owners { get; set; }
        DbSet<PropertyEntity> Properties { get; set; }
        DbSet<PropertyImageEntity> PropertyImages { get; set; }
        DbSet<PropertyTraceEntity> PropertyTraces { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();

        void RemoveRange(IEnumerable<object> entities);

        EntityEntry Remove(object entity);

        void UpdateRange(IEnumerable<object> entities);

        EntityEntry Update(object entity);
    }
}
