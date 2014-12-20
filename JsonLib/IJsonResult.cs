using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// A Json element
/// </summary>
public interface IJsonResult
{
    /// <summary>
    /// Converts this result to a JsonObject
    /// </summary>
    /// <returns>JsonObject</returns>
    JsonObject ToObject();

    /// <summary>
    /// Converts this result to a JsonArray
    /// </summary>
    /// <returns>JsonArray</returns>
    JsonArray ToArray();

    /// <summary>
    /// Encodes this object as json
    /// </summary>
    /// <returns>A Json string</returns>
    string ToJson();
}
