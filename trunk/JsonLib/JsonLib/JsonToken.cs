using System;
using System.Collections.Generic;
using System.Text;

internal enum JsonToken : int
{
    None = 0,
    CurlyOpen = 1,      // {
    CurlyClose = 2,     // }
    SquaredOpen = 3,    // [
    SquaredClose = 4,   // ]
    Colon = 5,          // :
    Comma = 6,          // ,
    String = 7,         // ""
    Number = 8,         // 123.45
    BoolTrue = 9,       // true
    BoolFalse = 10,     // false
    Null = 11           // null
}