using System.Reflection;

namespace Abc.Aids
{
    internal interface IPropertyAdapter
    {
        PropertyInfo PropInfo { get; }
        object PropValue { get; }
        public Type ItemType { get; }
        public Type PropType { get; }
        public Type UnderlyingTape { get; }
        public object Item { get; }
        void SetValue (object value);
    }
    public sealed class PropertyAdapter(object item, string propertyName) : IPropertyAdapter
    {
        public PropertyAdapter() : this(null, null) { }
        public PropertyInfo propInfo => ItemType?.GetProperty(propertyName);
        public PropertyInfo PropInfo => propInfo;
        public object Item => item;
        public object PropValue => PropInfo.GetValue(item);
        public Type ItemType => item?.GetType();
        public Type PropType => propInfo?.PropertyType;
        public Type UnderlyingTape => Nullable.GetUnderlyingType(PropType) ?? PropType;
        public void SetValue (object value) => propInfo?.SetValue(item, value);
    }
}
