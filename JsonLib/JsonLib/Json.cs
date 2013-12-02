using System;
using System.Collections.Generic;
using System.Text;

public class Json
{
    /// <summary>
    /// Enables the STRICT mode for JSON operations
    /// 
    /// If STRICT is on, all methods will throw exceptions.
    /// If STRICT is off, they will return NULL instead of throwing an exception
    /// </summary>
    public static bool STRICT = true;



    //
    //  ENCODE
    //
    protected static string encode(object value)
    {
        var encode = new JsonEncode();
        return encode.Serialize(value);
    }

    public static string Encode(JsonObject value)
    {
        return encode(value);
    }

    public static string Encode(JsonArray value)
    {
        return encode(value);
    }

    public static string Encode(string value)
    {
        return encode(value);
    }

    public static string Encode(bool value)
    {
        return encode(value);
    }

    public static string Encode(double value)
    {
        return encode(value);
    }


    //
    // DECODE
    //
    protected static object decode(string json)
    {
        var decode = new JsonDecode();
        return decode.ParseJson(json);
    }

    public static IJsonResult Decode(string json)
    {
        return (decode(json) as IJsonResult);
    }

    public static string DecodeString(string json)
    {
        return (decode(json) as String);
    }

    public static double? DecodeDouble(string json)
    {
        return (decode(json) as Double?);
    }

    public static bool? DecodeBool(string json)
    {
        return (decode(json) as Boolean?);
    }
}
