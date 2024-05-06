using System.ComponentModel;
using System.Globalization;

namespace Market.Extentions;

public static class EnumExtention
{
    public static string Description(this Enum value)
    {
        var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Any())
            return (attributes.First() as DescriptionAttribute).Description;

        // If no description is found, the least we can do is replace underscores with spaces
        // You can add your own custom default formatting logic here
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase(ti.ToLower(value.ToString().Replace("_", " ")));
    }
}