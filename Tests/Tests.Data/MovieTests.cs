using Abc.Data;
using Abc.Tests.Aids;
namespace Abc.Tests.Data;

[TestClass]
public sealed class MovieTests : BaseTests<Movie> 
{
    [TestMethod] public void IdTest() => IsProperty<Guid>(nameof(Movie.Id));
    [TestMethod] public void TitleTest() => IsProperty<string>(nameof(Movie.Name));
    [TestMethod] public void ReleaseDateTest() => IsProperty<DateTime?>(nameof(Movie.ValidFrom));
    [TestMethod] public void GenreTest() => IsProperty<string>(nameof(Movie.Genre));
    [TestMethod] public void PriceTest() => IsProperty<decimal>(nameof(Movie.Price));
}

