using Abc.Data;

namespace Abc.Infra
{
    public class MoviesRepo (ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo { }
    public class CountriesRepo (ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo { }
    public class CurrenicesRepo(ApplicationDbContext c = null) : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo { }
}
