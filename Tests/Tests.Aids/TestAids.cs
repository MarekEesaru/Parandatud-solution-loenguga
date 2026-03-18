using System.Formats.Asn1;
using System.Reflection;
namespace Abc.Tests.Aids;

public abstract class TestAids<TClass> : TestAids where TClass : class, new() {
    protected TClass obj;
    [TestInitialize] public virtual void Initialize() => Type = typeof(TClass);
    protected const BindingFlags publicDeclared = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;
    protected static IEnumerable<string> GetProperties() => Aids.GetType.PropertyNames<TClass>(publicDeclared);
    protected static IEnumerable<string> GetMethods() => Aids.GetType.MethodNames<TClass>(publicDeclared, false);
    protected void IsProperty<T>(string name) {
            var p = typeof(TClass).GetProperty(name);
            Assert.IsNotNull(p, NoProperty(name));
            Assert.AreEqual(typeof(T), p.PropertyType, WrongType<T>(name, p));
    }
    private static string WrongType<T>(string name, PropertyInfo p) => $"Property -{name}- in class -{typeof(TClass).Name}- is of type -{p.PropertyType.Name}- and not of type -{typeof(T).Name}-.";
    private static string NoProperty(string name) => $"Property -{name}- not found in class -{typeof(TClass).Name}-.";
}
public abstract class TestAids
{
    protected Type Type {  get; set; }
    [TestMethod] public void IsCorrectClassTest()
    {
        var className = Type?.Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(testClassName.Replace("Tests", ""), className);
    }
    public static void AreEqual<T>(T expected, T actual) => Assert.AreEqual(expected, actual);
    public static void AreSame(object expected, object actual) => Assert.AreEqual(expected, actual);
}