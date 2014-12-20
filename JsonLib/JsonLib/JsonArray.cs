using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/// <summary>
/// A JsonArray []
/// </summary>
public class JsonArray : ArrayList, IJsonResult
{
    /// <summary>
    /// Returns the given element as int
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A nullable integer</returns>
    public int? GetInt(int index)
    {
        return Caster.ParseInt(this[index], index);
    }

    /// <summary>
    /// Returns the given element as double
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A nullable double</returns>
    public double? GetDouble(int index)
    {
        return Caster.ParseDouble(this[index], index);
    }

    /// <summary>
    /// Returns the given element as bool
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A nullable boolean</returns>
    public bool? GetBool(int index)
    {
        return Caster.ParseBool(this[index], index);
    }

    /// <summary>
    /// Returns the given element as string
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A string (or null)</returns>
    public string GetString(int index)
    {
        return Caster.ParseString(this[index]);
    }

    /// <summary>
    /// Returns the given element as object
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A JsonObject (or null)</returns>
    public JsonObject GetObject(int index)
    {
        return Caster.ParseObject(this[index], index);
    }

    /// <summary>
    /// Returns the given element as array
    /// </summary>
    /// <param name="index">The index of the element</param>
    /// <returns>A JsonArray (or null)</returns>
    public JsonArray GetArray(int index)
    {
        return Caster.ParseArray(this[index], index);
    }

    /// <summary>
    /// You can't convert an array to an object!
    /// </summary>
    /// <returns>void</returns>
    public JsonObject ToObject()
    {
        throw new InvalidCastException("You can't cast a JsonArray to JsonObject!");
    }

    /// <summary>
    /// Returns a JsonArray
    /// </summary>
    /// <returns>JsonArray</returns>
    public new JsonArray ToArray()
    {
        return this;
    }

    /// <summary>
    /// Encodes this array as json
    /// </summary>
    /// <returns>A Json string</returns>
    public string ToJson()
    {
        return Json.Encode(this);
    }
}
