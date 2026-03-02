namespace Abc.Tests.Data;
public abstract class BaseTests<TClass> where TClass : class, new()
{
    protected TClass obj;
    [TestInitialize] public void Initialize() => obj = new TClass();
    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
    
    [TestMethod]
    public void IsClassCorrectTest()
    {
        var className = typeof(TClass).Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(testClassName.Replace("Tests", ""), className);
    }
    [TestMethod] public void IsClassTestedTest()
    {
        var testMethods = GetType().GetMethods();
        var classMembers = typeof(TClass).GetMembers();
        Assert.Inconclusive("Not all members are tested.");
    }
}
