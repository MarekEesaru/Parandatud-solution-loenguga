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
        private IQueryable<TEntity> set => db.Set<TEntity>();
        public async Task<int> CountAsync(Query q) => await set.CountAsync();
        public async Task<TEntity> CreateAsync(TEntity e) {await db.AddAsync(e); await db.SaveChangesAsync(); return e;}
        public Task DeleteAsync(Guid id) => DeleteCoreAsync(id);
        public async Task<TEntity> GetAsync(Guid id) => await set.FirstOrDefaultAsync(x => x.Id == id);
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
            var r = addSearch(set, q);
            r = addSort(r, q);
            r = addPagging(r, q);
            return await r.AsNoTracking().ToListAsync();
        }
        private static IQueryable<TEntity> addSearch(IQueryable<TEntity> r, Query q)
        {
            return r;
        }
        private static IQueryable<TEntity> addSort(IQueryable<TEntity> r, Query q)
        {
            var dir = q.SortDir;
            var key = sortBy(q.SortBy);
            if (key is null) return r;
            return (dir == "desc") ? r.OrderByDescending(key) : r.OrderBy(key);
        }
        private static IQueryable<TEntity> addPagging(IQueryable<TEntity> r, Query q)
        {
            var s = (q.Page - 1) * q.PageSize;
            var t = q.PageSize;
            return r.Skip(s).Take(t);
        }
        private static readonly BindingFlags flags
        = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
        private static PropertyInfo getProp(string propName) => typeof(TEntity).GetProperty(propName, flags);
        private static Expression<Func<TEntity, object>> sortBy(string propName)
        {
            var p = getProp(propName);
            if (p is null) return null;
            if (string.IsNullOrEmpty(propName)) return null;
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var member = Expression.Property(parameter, p);
            var converted = Expression.Convert(member, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(converted, parameter);
        }
    }
}
