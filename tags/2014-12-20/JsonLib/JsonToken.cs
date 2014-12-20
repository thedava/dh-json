using System;
using System.Collections.Generic;
using System.Text;

internal enum JsonToken : int
{
    /// <summary>
    /// No Token
    /// </summary>
    None = 0,

    /// <summary>
    /// Open curly bracket -> {
    /// </summary>
    CurlyOpen = 1,

    /// <summary>
    /// Closed curly bracket -> }
    /// </summary>
    CurlyClose = 2,

    /// <summary>
    /// Open squared bracket -> [
    /// </summary>
    SquaredOpen = 3,

    /// <summary>
    /// Closed squared bracket -> ]
    /// </summary>
    SquaredClose = 4,

    /// <summary>
    /// A colon -> :
    /// </summary>
    Colon = 5,

    /// <summary>
    /// A comma -> ,
    /// </summary>
    Comma = 6,

    /// <summary>
    /// A string -> ""
    /// </summary>
    String = 7,

    /// <summary>
    /// A number (float or int) -> 123.45
    /// </summary>
    Number = 8,

    /// <summary>
    /// A boolean true -> true
    /// </summary>
    BoolTrue = 9,

    /// <summary>
    /// A boolean false -> false
    /// </summary>
    BoolFalse = 10,

    /// <summary>
    /// An empty value -> null
    /// </summary>
    Null = 11
}