using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MosaicCRM.Domain.Common;

namespace MosaicCRM.EntityFramework;

public abstract class CrmDbContext<TDbContext> : DbContext, ICrmDbContext
    where TDbContext : DbContext
{

    protected CrmDbContext(DbContextOptions<TDbContext> options)
        : base(options)
    {
    }

    public IDbContextTransaction CreateTransaction()
    {
        return Database.BeginTransaction();
    }



    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if (ChangeTracker.HasChanges())
        {
            var date = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()
                         .Where(w => w.State == EntityState.Added || w.State == EntityState.Modified))
            {
                if (entry.Entity is ILastUpdatedTrackedEntity updatedEntity)
                {
                    updatedEntity.LastUpdatedAt=date;
                }

                if (entry.Entity is ICreateTrackedEntity createdEntity && entry.State == EntityState.Added)
                {
                    createdEntity.CreateAt = date;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}