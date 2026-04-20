using Abc.Aids;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Abc.Shared.Components;

public interface IEditorAdapter
{
    string DisplayName { get; }
    PropertyInfo PropInfo { get; }
    Type Editor { get; }
    Type Validator { get; }
    IDictionary<string, object> EditorParams { get; }
    IDictionary<string, object> ValidationParams { get; }
}

public sealed partial class EditorAdapter(ComponentBase c, object item, string propName) : IEditorAdapter
{
    public PropertyInfo PropInfo => ad?.PropInfo;
    public string DisplayName => HasName ? ToName : string.Empty;
    public Type Editor => UnderlyingType.IsString() ? typeof(InputText)
                        : UnderlyingType.IsBool() ? typeof(InputCheckbox)
                        : UnderlyingType.IsDate() ? Generic(typeof(InputDate<>), PropType)
                        : UnderlyingType.IsNumeric() ? Generic(typeof(InputNumber<>), PropType)
                        : null;
    public Type Validator => Generic(typeof(ValidationMessage<>), PropType);
    public IDictionary<string, object> EditorParams
        => new Dictionary<string, object>
        {
            ["id"] = propName,
            ["name"] = InputName,
            ["class"] = "form-control",
            ["Value"] = ad.PropValue,
            ["ValueChanged"] = ValChanged(),
            ["ValueExpression"] = ValExpression()
        };
    public IDictionary<string, object> ValidationParams
        => new Dictionary<string, object>
        {
            ["For"] = ValExpression(),
            ["class"] = "text-danger"
        };

    internal readonly IPropertyAdapter ad = new PropertyAdapter(item, propName);
    internal EventCallback<TValue> Changed<TValue>()
        => EventCallback.Factory.Create<TValue>(c, value => {
            ad.SetValue(value);
            return Task.CompletedTask;
        });
    internal Expression<Func<TValue>> Expression<TValue>()
    {
        var i = System.Linq.Expressions.Expression.Constant(item);
        var p = System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Convert(i, ad.ItemType), ad.PropInfo);
        return System.Linq.Expressions.Expression.Lambda<Func<TValue>>(p);
    }
    internal const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;
    internal bool HasName => !string.IsNullOrWhiteSpace(propName);
    internal string InputName => (ad?.ItemType is null) ? propName : $"{ad.ItemType.Name}.{propName}";
    internal object MakeGeneric(MethodInfo n) => n.MakeGenericMethod(ad.PropType).Invoke(this, null);
    internal static MethodInfo Method(string name) => typeof(EditorAdapter).GetMethod(name, flags);
    [GeneratedRegex("(\\B[A-Z])")] internal static partial Regex myRegex();
    internal Type PropType => ad?.PropType;
    internal string ToName => myRegex().Replace(propName, " $1");
    internal Type UnderlyingType => ad?.UnderlyingType ?? typeof(object);
    internal object ValChanged() => MakeGeneric(Method(nameof(Changed)));
    internal object ValExpression() => MakeGeneric(Method(nameof(Expression)));
    internal static Type Generic(Type editor, Type t) => editor.MakeGenericType(t);

}
