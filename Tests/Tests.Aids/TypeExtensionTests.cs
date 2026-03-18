using Abc.Aids;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Tests.Aids
{
    [TestClass] public class TypeExtensionTests : TestAids
    {
        [TestInitialize] public  void Initialize() => Type = typeof(TypeExtension);
        [TestMethod] public void IsBoolTest() 
        { 
            Assert.IsTrue(TypeExtension.IsBool(typeof(bool))); 
            Assert.IsFalse(TypeExtension.IsBool(typeof(int)));
        }
        [TestMethod] public void IsBoolNullableTest() 
        {

        }
        [TestMethod] public void IsDateTest() 
        { 
            Assert.IsTrue(TypeExtension.IsDate(typeof(DateTime)));
            Assert.IsTrue(TypeExtension.IsDate(typeof(DateOnly)));
            Assert.IsFalse(TypeExtension.IsDate(typeof(int)));
        }
        [TestMethod] public void IsDateNullableTest()
        {

        }
        [TestMethod] public void IsStringTest() 
        {
            Assert.IsTrue(TypeExtension.IsString(typeof(string)));
            Assert.IsFalse(TypeExtension.IsString(typeof(int)));
        }
        [TestMethod] public void IsStringNullableTest()
        {

        }

        [DataRow(typeof(sbyte))]
        [DataRow(typeof(sbyte?))]
        [DataRow(typeof(byte))]
        [DataRow(typeof(byte?))]

        [TestMethod] public void IsNumericTest(Type t) 
        { 
            Assert.IsTrue(TypeExtension.IsNumeric(t)); 
        }

}
}
