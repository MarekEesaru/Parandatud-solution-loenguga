using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Abc.Infra
{
    public class EfBaseRepo<TContext, TEntity> (TContext c) : IRepo<TEntity> where TContext : DbContext where TEntity : BaseEntity
    {
        protected readonly TContext db = c;
        public async Task<int> CountAsync(Query q) => await db.Set<TEntity>().CountAsync();
        public async Task<TEntity> CreateAsync(TEntity e) {await db.AddAsync(e); await db.SaveChangesAsync(); return e;}
        public Task DeleteAsync(Guid id) => DeleteCoreAsync(id);
        public async Task<TEntity> GetAsync(Guid id) => await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<TEntity>> GetAsync(Query q) => await GetAllCoreAsync(q);
        public async Task<TEntity> UpdateAsync(TEntity e) { db.Update(e); await db.SaveChangesAsync(); return e;}
        private async Task DeleteCoreAsync(Guid id) 
        {
            var entity = await GetAsync(id);
            if (entity is null) return;
            db.Remove(entity);
            await db.SaveChangesAsync();
        }
        private async Task<IEnumerable<TEntity>> GetAllCoreAsync(Query q)
        {
            var s = (q.Page-1) * q.PageSize;
            var t = q.PageSize;
            var r = db.Set<TEntity>().Skip(s).Take(t).OrderBy(x => x.ValidTo).AsNoTracking();
            return await r.ToListAsync();
        }
    }
}
