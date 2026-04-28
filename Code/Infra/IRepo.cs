using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data;
using Abc.Data.Common;

namespace Abc.Infra
{
    public interface IRepo<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Guid id);
        Task<int> CountAsync();
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TEntity e);
        Task<TEntity> UpdateAsync(TEntity e);
        Task DeleteAsync(Guid id);
    }
    public interface IMoviesRepo : IRepo<Movie> { }
    public interface ICountriesRepo : IRepo<Country> { }
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public interface IMoniesRepo : IRepo<Money> { }
    public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }

}
