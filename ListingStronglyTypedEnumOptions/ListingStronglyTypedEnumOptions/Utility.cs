using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ListingStronglyTypedEnumOptions
{
    public static class Utility
    {
        public static string GetEnumName<T>(T value)
        {
            return Enum.GetName(typeof(T), value);
        }
        public static string GetMultipleEnumsName<T>(string values)
        {
            if (string.IsNullOrEmpty(values)) return string.Empty;
            string newValuesName = null;
            string[] valuesArray = values.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in valuesArray)
            {
                if (string.IsNullOrEmpty(newValuesName))
                    newValuesName = $"{Enum.Parse(typeof(T), value)}";
                else newValuesName += $",{Enum.Parse(typeof(T), value)}";
            }
            return newValuesName;

        }
        public static string? GetEnumDisplayName<T>(T value)
        {
            return value?
                      .GetType()?
                      .GetMember(value.ToString())
                      .First()
                      .GetCustomAttribute<DisplayAttribute>()
                      ?.GetName();
        }
        public static string GetMultipleEnumsDisplayName<T>(string values)
        {
            if (string.IsNullOrEmpty(values)) return string.Empty;
            var enumValues = values.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(v => Enum.Parse(typeof(T), v.Trim()))
                              .Cast<Enum>()
                              .ToList(); 
            var displayNames = enumValues.Select(enumValue => GetEnumDisplayName(enumValue)); 
            return string.Join(", ", displayNames); 
        }
    }
}
