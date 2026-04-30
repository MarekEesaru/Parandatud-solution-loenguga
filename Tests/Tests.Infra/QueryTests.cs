using Abc.Aids;
using Abc.Infra;
using Abc.Tests.Aids;

namespace Abc.Tests.Infra;

[TestClass]
public class QueryTests : BaseTests<Query>
{
    private readonly int[] pageSizes = [7, 15, 25, 50, 100];
    [TestMethod]
    public void PageSizesTest()
    {
        areEqual(pageSizes.Length, Query.PageSizes.Length);
        for (var i = 0; i < pageSizes.Length; i++)
            areEqual(pageSizes[i], Query.PageSizes[i]);
    }
    [TestMethod] public void PageTest() => areEqual(1, obj.Page);
    [TestMethod] public void PageSizeTest() => areEqual(pageSizes[0], obj.PageSize);
    [TestMethod] public void SortByTest() => areEqual("", obj.SortBy);
    [TestMethod] public void SortDirTest() => areEqual("", obj.SortDir);
    [TestMethod] public void SearchByTest() => areEqual("", obj.SearchBy);
    [TestMethod] public void SelectedTest() => areEqual("", obj.Selected);
    [TestMethod] public void SearchStrTest() => areEqual("", obj.SearchStr);
    [TestMethod] public void HrefTest() => areEqual("", obj.Href(null));
    [TestMethod] public void SortHrefTest() => areEqual("", obj.Href(null, null, null));
    [TestMethod] public void PageHrefTest() => areEqual("", obj.Href(null, null));
    [TestMethod] public void SelectHrefTest() => areEqual("", obj.Href(null, Guid.Empty));
}

