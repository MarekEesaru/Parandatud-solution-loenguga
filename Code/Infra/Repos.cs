using Abc.Data;

namespace Abc.Infra
{
    public class MoviesRepo (ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo { }
    public class CountriesRepo (ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo { }
    public class CurrenciesRepo(ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo { }
    public class MoniesRepo(ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Money>(c), IMoniesRepo { }
    public class CountryCurrenciesRepo(ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, CountryCurrency>(c), ICountryCurrenciesRepo { }
}
