using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Globalization;

internal class JsonDecode
{
    private int index = 0;
    private bool success = true;

    public object ParseJson(string json)
    {
        object result = parseValue(json.ToCharArray());

        if (!success && Json.STRICT)
        {
            throw new Exception("JSON Decode failed at " + index + "/" + json.Length + "!");
        }
        return (success) ? result : null;
    }

    protected object parseValue(char[] json)
    {
        switch (previewNextChar(json))
        {
            case JsonToken.String:
                return parseString(json);

            case JsonToken.Number:
                return parseNumber(json);

            case JsonToken.CurlyOpen:
                return parseObject(json);

            case JsonToken.SquaredOpen:
                return parseArray(json);

            case JsonToken.BoolTrue:
                nextChar(json, ref index);
                return true;

            case JsonToken.BoolFalse:
                nextChar(json, ref index);
                return false;

            case JsonToken.Null:
                nextChar(json, ref index);
                return null;

            case JsonToken.None:
                break;
        }

        success = false;
        return null;
    }

    protected JsonObject parseObject(char[] json)
    {
        bool done = false;
        JsonObject jsonObject = new JsonObject();

        nextChar(json, ref index);

        while (!done)
        {
            switch (previewNextChar(json))
            {
                case JsonToken.None:
                    success = false;
                    return null;

                case JsonToken.Comma:
                    nextChar(json, ref index);
                    break;

                case JsonToken.CurlyClose:
                    nextChar(json, ref index);
                    done = true;
                    break;

                default:
                    string name = parseString(json);
                    if (!success)
                    {
                        return null;
                    }

                    if ((nextChar(json, ref index)) != JsonToken.Colon)
                    {
                        success = false;
                        return null;
                    }
                    else
                    {
                        object value = parseValue(json);
                        if (!success)
                        {
                            success = false;
                            return null;
                        }
                        jsonObject.Add(name, value);
                    }
                    break;
            }
        }
        return jsonObject;
    }

    protected JsonArray parseArray(char[] json)
    {
        bool done = false;
        JsonArray array = new JsonArray();

        nextChar(json, ref index);

        while (!done)
        {
            switch (previewNextChar(json))
            {
                case JsonToken.None:
                    success = false;
                    return null;

                case JsonToken.Comma:
                    nextChar(json, ref index);
                    break;

                case JsonToken.SquaredClose:
                    nextChar(json, ref index);
                    return array;

                default:
                    object value = parseValue(json);
                    if (!success)
                    {
                        return null;
                    }
                    array.Add(value);
                    break;
            }
        }

        return array;
    }

    protected string parseString(char[] json)
    {
        StringBuilder builder = new StringBuilder();
        trim(json);

        index++; // Skip first "
        char currentChar;

        bool breakLoop = false;
        while (!breakLoop && index < json.Length)
        {
            currentChar = json[index++];
            if (currentChar == '"')
            {
                return builder.ToString();
            }
            else if (currentChar == '\\')
            {
                currentChar = json[index++];

                switch (currentChar)
                {
                    case 'b':
                    case 'f':
                    case 'n':
                    case 'r':
                    case 't':
                        builder.Append('\\');
                        goto case '"';

                    case '"':
                    case '\\':
                    case '/':
                        builder.Append(currentChar);
                        break;

                    case 'u':

                        int remainingLength = json.Length - index;
                        if (remainingLength >= 4)
                        {
                            char[] unicodeCharArray = new char[4];
                            Array.Copy(json, index, unicodeCharArray, 0, 4);
                            uint codePoint = Convert.ToUInt32(new string(unicodeCharArray), 16);
                            builder.Append(Char.ConvertFromUtf32((int)codePoint));
                            index += 4;
                        }
                        else
                        {
                            breakLoop = true; // While Break
                        }

                        break;
                }
            }
            else
            {
                builder.Append(currentChar);
            }
        }

        success = false;
        return null;
    }

    protected double parseNumber(char[] json)
    {
        trim(json);

        int lastIndex = getEndOfNumber(json);
        int charLength = (lastIndex - index) + 1;
        char[] numbers = new char[charLength];

        Array.Copy(json, index, numbers, 0, charLength);
        index = lastIndex + 1;
        return Convert.ToDouble(new string(numbers), CultureInfo.InvariantCulture);
    }

    protected int getEndOfNumber(char[] json)
    {
        int lastIndex;
        for (lastIndex = index; lastIndex < json.Length; lastIndex++)
        {
            if ("0123456789+-.eE".IndexOf(json[lastIndex]) == -1)
                break;
        }
        return lastIndex - 1;
    }

    protected void trim(char[] json)
    {
        for (; index < json.Length; index++)
        {
            if (" \t\n\r".IndexOf(json[index]) == -1)
                break;
        }
    }

    protected JsonToken previewNextChar(char[] json)
    {
        int tmp = index;
        return nextChar(json, ref tmp);
    }

    protected bool checkKeyWord(string keyword, char[] json, int remainingLength, ref int index)
    {
        if (remainingLength < keyword.Length)
        {
            return false;
        }

        int i = index;
        char[] Compare = keyword.ToCharArray();

        for (i = 0; i < Compare.Length; i++)
        {
            if (Compare[i] != json[i + index]) return false;
        }
        index += i;
        return true;
    }

    protected JsonToken nextChar(char[] json, ref int i)
    {
        trim(json);
        if (i >= json.Length)
        {
            return JsonToken.None;
        }

        switch (json[i++])
        {
            case '{':
                return JsonToken.CurlyOpen;

            case '}':
                return JsonToken.CurlyClose;

            case '[':
                return JsonToken.SquaredOpen;

            case ']':
                return JsonToken.SquaredClose;

            case ',':
                return JsonToken.Comma;

            case '"':
                return JsonToken.String;

            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case '-':
                return JsonToken.Number;

            case ':':
                return JsonToken.Colon;
        }
        i--;

        int remainingLength = json.Length - i;

        if (checkKeyWord("false", json, remainingLength, ref i))
        {
            return JsonToken.BoolFalse;
        }
        else if (checkKeyWord("true", json, remainingLength, ref i))
        {
            return JsonToken.BoolTrue;
        }
        else if (checkKeyWord("null", json, remainingLength, ref i))
        {
            return JsonToken.Null;
        }

        return JsonToken.None;
    }
}
