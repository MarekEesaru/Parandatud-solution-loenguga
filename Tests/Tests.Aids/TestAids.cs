using System.Reflection;

namespace Abc.Tests.Aids;

public abstract class TestAids<TClass> where TClass : class, new()
{
    protected TClass obj;
    protected const BindingFlags publicDeclared = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static;
    protected static IEnumerable<string> GetProperties() => Aids.GetType.PropertyNames<TClass>(publicDeclared);
    protected static IEnumerable<string> GetMethods() => Aids.GetType.MethodNames<TClass>(publicDeclared, false);
}