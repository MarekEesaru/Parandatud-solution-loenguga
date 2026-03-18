using Abc.Aids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Tests.Aids
{
    [TestClass] public class TypeExtensionTests : TestAids
    {
        [TestInitialize] public  void Initialize() => type = typeof(TypeExtension);
        [TestMethod] public void IsBoolTest() { Assert.Inconclusive(); }

    }
}
