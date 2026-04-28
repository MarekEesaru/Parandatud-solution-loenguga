using Abc.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
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
            var s = (q.Page - 1) * q.PageSize;
            var t = q.PageSize;
            var dir = q.SortDir;
            var n = q.SortBy;
            var key = (n is null) ? null : sortBy(n);
            var r = key == null
                ? db.Set<TEntity>().Skip(s).Take(t).AsNoTracking()
                : (dir == "desc") 
                   ? db.Set<TEntity>().Skip(s).Take(t).OrderByDescending(key).AsNoTracking()
                   : db.Set<TEntity>().Skip(s).Take(t).OrderBy(key).AsNoTracking();
            return await r.ToListAsync();
        }
        private static readonly BindingFlags flags
        = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
        private static Expression<Func<TEntity, object>> sortBy(string propName)
        {
            var p = typeof(TEntity).GetProperty(propName, flags);
            if (p is null) return null;
            if (string.IsNullOrEmpty(propName)) return null;
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var member = Expression.Property(parameter, p);
            var converted = Expression.Convert(member, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(converted, parameter);
        }
    }
}
