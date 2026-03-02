using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Abc.Tests.Data;
public abstract class BaseTests<TClass> where TClass : class, new()
{
    protected TClass obj;
    private const BindingFlags publicDeclared = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;
    [TestInitialize] public void Initialize() => obj = new TClass();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    
    [TestMethod]
    public void IsCorrectClassTest()
    {
        var className = typeof(TClass).Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(testClassName.Replace("Tests", ""), className);
    }
    [TestMethod] public void IsClassTestedTest()
    {
        var testMethods = GetType().GetMethods().Select(x => x.Name);
        var membersToTest = GetProperties().Concat(GetMethods());
        foreach (var m in membersToTest)
        {
            if ( !testMethods.Contains(m + "Test"))
                Assert.Inconclusive($"{m} is not tested!");
        }
    }
    
    private static IEnumerable<string> GetProperties() => Aids.GetType.PropertyNames<TClass>(publicDeclared);
    private static IEnumerable<string> GetMethods() => Aids.GetType.MethodNames<TClass>(publicDeclared, false);
}
