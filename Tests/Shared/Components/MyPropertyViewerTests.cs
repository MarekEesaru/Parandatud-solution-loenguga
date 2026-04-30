using Abc.Aids;
using Abc.Shared.Components;
using Abc.Tests.Aids;

namespace Abc.Tests.Shared.Components;

[TestClass] public sealed class MyPropertyViewerTests : BaseTests<MyPropertyViewer>
{
    private MyPropertyViewer o;
    private string l;
    private string v;
    [TestInitialize] override public void Initialize()
    {
        base.Initialize();
        l = GetRandom.String(5, 10);
        v = GetRandom.String(5, 10);
        o = new MyPropertyViewer { Label = l, Value = v };
    }
    [TestMethod] public void LabelTest()
    {
        areEqual(string.Empty, obj.Label);
        areEqual(l, o.Label);
    }
    [TestMethod] public void ValueTest()
    {
        areEqual(null, obj.Value);
        areEqual(v, o.Value);
    }
}

