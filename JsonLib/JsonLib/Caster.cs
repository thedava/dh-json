using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This class is for converting values into other types
/// </summary>
public class Caster
{
    /// <summary>
    /// Creates a caster exception (if strict mode is enabled)
    /// </summary>
    /// <param name="field">The field that is invalid</param>
    /// <param name="dataType">The expected data type</param>
    /// <param name="error">The original cast exception</param>
    private static void throwError(object field, string dataType, Exception error = null)
    {
        string def = (field is Int32) ? "index" : "field";
        string msg = "The " + def + " '" + field + "' does not contain an " + dataType + "!";

        throw (error == null) ? new InvalidCastException(msg) : new InvalidCastException(msg, error);
    }

    /// <summary>
    /// Tries to parse a value as int
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <param name="field">The original index of this element</param>
    /// <returns>A nullable integer</returns>
    public static int? ParseInt(object value, object field)
    {
        int? result = null;
        try
        {
            result = Int32.Parse(ParseString(value));
        }
        catch (Exception error)
        {
            if (Json.STRICT && !result.HasValue)
            {
                throwError(field, "Int32", error);
            }
        }
        return result;
    }

    /// <summary>
    /// Tries to parse a value as string
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <returns>A string (or null)</returns>
    public static string ParseString(object value)
    {
        return value.ToString();
    }

    /// <summary>
    /// Tries to parse a value as double
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <param name="field">The original index of this element</param>
    /// <returns>A nullable double</returns>
    public static double? ParseDouble(object value, object field)
    {
        double? result = null;
        try
        {
            result = Convert.ToDouble(ParseString(value).Replace('.', ','));
        }
        catch (Exception error)
        {
            if (Json.STRICT && !result.HasValue)
            {
                throwError(field, "Double", error);
            }
        }
        return result;
    }

    /// <summary>
    /// Tries to parse a value as bool
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <param name="field">The original index of this element</param>
    /// <returns>A nullable boolean</returns>
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
            {
                throwError(field, "Boolean", error);
            }
        }
        return result;
    }

    /// <summary>
    /// Tries to parse a value as json object
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <param name="field">The original index of this element</param>
    /// <returns>A JsonObject (or null)</returns>
    public static JsonObject ParseObject(object value, object field)
    {
        JsonObject result = (value as JsonObject);

        if (Json.STRICT && result == null)
        {
            throwError(field, "JsonObject");
        }

        return result;
    }

    /// <summary>
    /// Tries to parse a value as json array
    /// </summary>
    /// <param name="value">The value that should be converted</param>
    /// <param name="field">The original index of this element</param>
    /// <returns>A JsonArray (or null)</returns>
    public static JsonArray ParseArray(object value, object field)
    {
        JsonArray result = (value as JsonArray);

        if (Json.STRICT && result == null)
        {
            throwError(field, "JsonArray");
        }

        return result;
    }
}