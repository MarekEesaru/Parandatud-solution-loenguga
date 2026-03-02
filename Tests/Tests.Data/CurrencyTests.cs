using Abc.Data;

namespace Abc.Tests.Data;

[TestClass]
public class CurrencyTests
{
    private Currency currency;

    [TestInitialize] public void Initialize() => currency = new Currency();

    [TestMethod]
    public void CanCreateTest()
    {
        Assert.IsNotNull(currency);
    }
}
