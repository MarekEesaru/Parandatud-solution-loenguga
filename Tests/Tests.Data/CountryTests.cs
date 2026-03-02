using Abc.Data;
using System.Diagnostics.Metrics;

namespace Abc.Tests.Data;

[TestClass]
public class CountryTests
{
    private Country country;

    [TestInitialize] public void Initialize() => country = new Country();

    [TestMethod]
    public void CanCreateTest()
    {
        Assert.IsNotNull(country);
    }
}
