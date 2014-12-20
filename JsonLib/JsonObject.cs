using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/// <summary>
/// A JsonObject {}
/// </summary>
public class JsonObject : Hashtable, IJsonResult
{
    /// <summary>
    /// Returns the given element as int
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A nullable integer</returns>
    public int? GetInt(object field)
    {
        return Caster.ParseInt(this[field], field);
    }

    /// <summary>
    /// Returns the given element as double
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A nullable double</returns>
    public double? GetDouble(object field)
    {
        return Caster.ParseDouble(this[field], field);
    }

    /// <summary>
    /// Returns the given element as bool
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A nullable boolean</returns>
    public bool? GetBool(object field)
    {
        return Caster.ParseBool(this[field], field);
    }

    /// <summary>
    /// Returns the given element as string
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A string (or null)</returns>
    public string GetString(object field)
    {
        return Caster.ParseString(this[field]);
    }

    /// <summary>
    /// Returns the given element as object
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A JsonObject (or null)</returns>
    public JsonObject GetObject(object field)
    {
        return Caster.ParseObject(this[field], field);
    }

    /// <summary>
    /// Returns the given element as array
    /// </summary>
    /// <param name="field">The index of the element</param>
    /// <returns>A JsonArray (or null)</returns>
    public JsonArray GetArray(object field)
    {
        return Caster.ParseArray(this[field], field);
    }

    /// <summary>
    /// Returns a JsonObject
    /// </summary>
    /// <returns>JsonObject</returns>
    public JsonObject ToObject()
    {
        return this;
    }

    /// <summary>
    /// You can't convert an object to an array
    /// </summary>
    /// <returns>void</returns>
    public JsonArray ToArray()
    {
        throw new InvalidCastException("You can't cast a JsonObject to JsonArray!");
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