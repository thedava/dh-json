using System;
using System.Collections.Generic;
using System.Text;

internal class Caster
{
    private static void throwError(object field, string dataType, Exception error = null)
    {
        string def = (field is Int32) ? "index" : "field";
        string msg = "The " + def + " '" + field + "' does not contain an " + dataType + "!";

        throw (error == null) ? new InvalidCastException(msg) : new InvalidCastException(msg, error);
    }

    public static int? ParseInt(object value, object field)
    {
        int? result = null;
        try
        {
            result = Convert.ToInt32(value);
        }
        catch (Exception error)
        {
            if (Json.STRICT && !result.HasValue)
                throwError(field, "Int32", error);
        }
        return result;
    }

    public static string ParseString(object value)
    {
        return value.ToString();
    }

    public static double? ParseDouble(object value, object field)
    {
        double? result = null;
        try
        {
            result = Convert.ToDouble(value);
        }
        catch (Exception error)
        {
            if (Json.STRICT && !result.HasValue)
                throwError(field, "Double", error);
        }
        return result;
    }

    public static bool? ParseBool(object value, object field)
    {
        bool? result = null;
        try
        {
            result = Convert.ToBoolean(value);
        }
        catch (Exception error)
        {
            if (Json.STRICT && !result.HasValue)
                throwError(field, "Boolean", error);
        }
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