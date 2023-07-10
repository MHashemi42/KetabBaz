using System;
using System.Reflection;

namespace KetabBaz.Web.Helpers;

public static class StringDictionryConverter
{
    public static Dictionary<string, string> ToDictionary(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

        return props.ToDictionary(prop => prop.Name.ToLower(),
            prop => prop.GetValue(obj, null)?.ToString());
    }
}
