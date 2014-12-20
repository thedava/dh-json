using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// JSON Encoding and Decoding
/// </summary>
public class Json
{
    /// <summary>
    /// Enables the STRICT mode for JSON operations
    /// 
    /// If STRICT is on, all methods will throw exceptions.
    /// If STRICT is off, they will return NULL instead of throwing an exception
    /// </summary>
    public static bool STRICT = true;


    #region Encode

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    protected static string encode(object value)
    {
        var encode = new JsonEncode();
        return encode.Serialize(value);
    }

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    public static string Encode(JsonObject value)
    {
        return encode(value);
    }

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    public static string Encode(JsonArray value)
    {
        return encode(value);
    }

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    public static string Encode(string value)
    {
        return encode(value);
    }

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    public static string Encode(bool value)
    {
        return encode(value);
    }

    /// <summary>
    /// Tries to encode the given value to json
    /// </summary>
    /// <param name="value">The value</param>
    /// <returns>A json string</returns>
    public static string Encode(double value)
    {
        return encode(value);
    }

    #endregion



    #region Decode

    /// <summary>
    /// Tries to decode the given json string
    /// </summary>
    /// <param name="json">The json string</param>
    /// <returns>An object</returns>
    protected static object decode(string json)
    {
        var decode = new JsonDecode();
        return decode.ParseJson(json);
    }

    /// <summary>
    /// Tries to decode the given json string
    /// </summary>
    /// <param name="json">The json string</param>
    /// <returns>A JsonResult (JsonObject or JsonArray)</returns>
    public static IJsonResult Decode(string json)
    {
        return (decode(json) as IJsonResult);
    }

    /// <summary>
    /// Tries to decode the given json string
    /// </summary>
    /// <param name="json">The json string</param>
    /// <returns>A string</returns>
    public static string DecodeString(string json)
    {
        return (decode(json) as String);
    }

    /// <summary>
    /// Tries to decode the given json string
    /// </summary>
    /// <param name="json">The json string</param>
    /// <returns>A double</returns>
    public static double? DecodeDouble(string json)
    {
        return (decode(json) as Double?);
    }

    /// <summary>
    /// Tries to decode the given json string
    /// </summary>
    /// <param name="json">The json string</param>
    /// <returns>A boolean</returns>
    public static bool? DecodeBool(string json)
    {
        return (decode(json) as Boolean?);
    }

    #endregion
}
