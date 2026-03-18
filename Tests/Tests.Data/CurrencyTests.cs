using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass]
public sealed class CurrencyTests : BaseTests<Currency> 
{
    [TestMethod] public void NumericCodeTest() => IsProperty<string>(nameof(Currency.NumericCode));
    [TestMethod] public void MajorUnitSymbolTest() => IsProperty<string>(nameof(Currency.MajorUnitSymbol));
    [TestMethod] public void MinorUnitSymbolTest() => IsProperty<string>(nameof(Currency.MinorUnitSymbol));
    [TestMethod] public void RatioOfMinorUnitTest() => IsProperty<double>(nameof(Currency.RatioOfMinorUnit));
    [TestMethod] public void IsIsoCurrencyTest() => IsProperty<bool>(nameof(Currency.IsIsoCurrency));

}

