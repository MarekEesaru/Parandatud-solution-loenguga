using Abc.Data;
namespace Abc.Tests.Data
{
    [TestClass]
    public sealed class MovieTests : BaseTests<Movie> { }
    [TestClass]
    public class CountryTests : BaseTests<Country> { }
    [TestClass]
    public class CurrencyTests : BaseTests<Currency> { }
    public abstract class BaseTests<TClass> where TClass : class, new()
    {
        protected TClass obj;
        [TestInitialize] public void Initialize() => obj = new TClass();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    }
}
