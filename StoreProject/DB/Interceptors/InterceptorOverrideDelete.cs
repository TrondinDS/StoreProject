using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StoreProject.DB.Models.Interfaces;

namespace StoreProject.DB.Interceptors
{
    public class InterceptorOverrideDelete : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData dbEvent, InterceptionResult<int> result)
        {
            if (dbEvent.Context is null) return result;

            foreach (var item in dbEvent.Context.ChangeTracker.Entries())
            {
                if (item is not { State: EntityState.Deleted, Entity: IsDelete delete }) continue;
                item.State = EntityState.Modified;
                delete.IsDeleted = true;
            }
            return result;
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData dbEvent, InterceptionResult<int> result, CancellationToken token = default)
        {
            if (dbEvent.Context is null) return await  Task.FromResult(result);

            foreach (var item in dbEvent.Context.ChangeTracker.Entries())
            {
                if (item is not { State: EntityState.Deleted, Entity: IsDelete delete }) continue;
                item.State = EntityState.Modified;
                delete.IsDeleted = true;
            }
            return await Task.FromResult(result);
        }
    }
}
