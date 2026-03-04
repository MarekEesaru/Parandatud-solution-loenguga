using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Abc.Aids
{
    public static class Clone
    {
        public static TClass Object<TClass>(TClass obj) where TClass : class, new() => (TClass)Cclone(obj);
        private const BindingFlags publicInstance = BindingFlags.Public | BindingFlags.Instance;
        private static object Cclone(object obj)
        {
            if (obj == null) return null;
            var t = obj.GetType();
            var o = Activator.CreateInstance(t);
            var props = t.GetProperties(publicInstance);
            Ccopy(obj, o, props);
            return o;
        }
        private static void Ccopy(object from, object to, PropertyInfo[] props)
        {
            foreach (var p in props)
            {
                if (!p.CanRead || !p.CanWrite) continue;
                var v = p.GetValue(from);
                if (v != null && IsClass(p)) 
                    v = Cclone(v);
                p.SetValue(to, v);
            }
        }
        private static bool IsClass(PropertyInfo p) => p.PropertyType.IsClass && p.PropertyType != typeof(string);
    }
}
