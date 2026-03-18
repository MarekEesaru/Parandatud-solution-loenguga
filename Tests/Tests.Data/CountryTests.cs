using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass]
public sealed class CountryTests : BaseTests<Country> 
{
    [TestMethod] public void OfficialNameTest() => IsProperty<string>(nameof(Country.OfficialName));
    [TestMethod] public void NativeNameTest() => IsProperty<string>(nameof(Country.NativeName));
    [TestMethod] public void NumericCodeTest() => IsProperty<string>(nameof(Country.NumericCode));
    [TestMethod] public void IsoCodeTest() => IsProperty<string>(nameof(Country.IsoCode));
}
