using System;
using System.Collections.Generic;
using System.Text;

internal class Caster
{
    private static void throwError(object field, string dataType)
    {
        string def = (field is Int32) ? "index" : "field";
        throw new InvalidCastException("The " + def + " '" + field + "' does not contain an " + dataType + "!");
    }

    public static int? ParseInt(object value, object field)
    {
        int? result = (value as Int32?);

        if (Json.STRICT && !result.HasValue)
            throwError(field, "Int32");

        return result;
    }

    public static string ParseString(object value)
    {
        return value.ToString();
    }

    public static double? ParseDouble(object value, object field)
    {
        double? result = (value as Double?);

        if (Json.STRICT && !result.HasValue)
            throwError(field, "Double");

        return result;
    }

    public static bool? ParseBool(object value, object field)
    {
        bool? result = (value as Boolean?);

        if (Json.STRICT && !result.HasValue)
            throwError(field, "Boolean");

        return result;
    }

    public static JsonObject ParseObject(object value, object field)
    {
        JsonObject result = (value as JsonObject);

        if (Json.STRICT && result == null)
            throwError(field, "JsonObject");

        return result;
    }

    public static JsonArray ParseArray(object value, object field)
    {
        JsonArray result = (value as JsonArray);

        if (Json.STRICT && result == null)
            throwError(field, "JsonArray");

        return result;
    }
}