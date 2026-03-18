using Abc.Aids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Tests.Aids
{
    [TestClass] public class PropertyAdapterTests : BaseTests<PropertyAdapter>
    {
        private class testClass
        {
            public int? IntProp { get; set; }
            public string StringProp { get; set; }
        }
        private testClass item;
        private string propName = nameof(testClass.IntProp);
        private PropertyAdapter objStr;
        [TestInitialize] public override void Initialize()
        {
            base.Initialize();
            item = new testClass();
            obj = new PropertyAdapter(item, propName);
            objStr = new PropertyAdapter(item, nameof(testClass.StringProp));
        }
        [TestMethod] public void ItemTypeTest() => AreEqual(typeof(testClass), obj.ItemType);
        [TestMethod] public void ItemTest() => AreSame(item, obj.Item);
        [TestMethod] public void PropInfoTest() => AreEqual(propName, obj.PropInfo.Name);
        [TestMethod] public void PropTypeTest()
        {
            AreEqual(typeof(int?), obj.PropType);
            AreEqual(typeof(string), objStr.PropType);
        }
        [TestMethod] public void UnderlyingTypeTest()
        {
            AreEqual(typeof(int), obj.UnderlyingType);
            AreEqual(typeof(string), objStr.UnderlyingType);
        }
        [TestMethod] public void PropValueTest()
        {
            AreEqual(null, obj.PropValue);
            AreEqual(null, objStr.PropValue);
        }
        [TestMethod] public void SetValueTest()
        {
            var i = GetRandom.Int32();
            var s = GetRandom.String();
            obj.SetValue(i);
            objStr.SetValue(s);
            AreEqual(i, item.IntProp);
            AreEqual(s, item.StringProp);
            AreEqual(obj.PropValue, item.IntProp);
            AreEqual(objStr.PropValue, item.StringProp);
        }
    }
}
