using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Market.Extentions;

namespace Market.Converters;


public class EnumToCollectionConverter: MarkupExtension
{
    private readonly Type _type;

    public EnumToCollectionConverter(Type type)
    {
        _type = type;
    }
    
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Enum.GetValues(_type)
            .Cast<object>()
            .Select(e => new { Value = e, DisplayName = (e as Enum).Description() });
    }
}