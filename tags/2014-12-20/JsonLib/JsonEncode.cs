using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Globalization;

internal class JsonEncode
{
    protected bool success = true;
    protected StringBuilder builder = new StringBuilder();

    public string Serialize(object value)
    {
        serializeValue(value);
        if (!success && Json.STRICT)
        {
            throw new Exception("JSON Encode failed!");
        }
        return (success) ? builder.ToString() : null;
    }

    protected bool serializeValue(object value)
    {
        if (value is String)
        {
            success = serializeString((string)value);
        }
        else if (value is JsonObject || value is Hashtable)
        {
            success = serializeObject((JsonObject)value);
        }
        else if (value is JsonArray || value is ArrayList)
        {
            success = serializeArray((JsonArray)value);
        }
        else if (isNumeric(value))
        {
            success = serializeNumber(Convert.ToDouble(value));
        }
        else if ((value is Boolean))
        {
            if ((Boolean)value == true)
            {
                builder.Append("true");
            }
            else
            {
                builder.Append("false");
            }
        }
        else if (value == null)
        {
            builder.Append("null");
        }
        else
        {
            success = false;
        }

        return success;
    }

    protected bool serializeObject(JsonObject jsonObject)
    {
        builder.Append("{");
        bool first = true;

        foreach(DictionaryEntry e in jsonObject)
        {
            string key = e.Key.ToString();
            object value = e.Value;

            if (!first)
            {
                builder.Append(",");
            }

            serializeString(key);
            builder.Append(":");

            if (!serializeValue(value))
            {
                return false;
            }

            first = false;
        }

        builder.Append("}");
        return true;
    }

    protected bool serializeArray(JsonArray jsonArray)
    {
        builder.Append("[");

        bool first = true;
        for (int i = 0; i < jsonArray.Count; i++)
        {
            if (!first)
            {
                builder.Append(",");
            }
            else
            {
                first = false;
            }

            if (!serializeValue(jsonArray[i]))
            {
                return false;
            }
        }

        builder.Append("]");
        return true;
    }

    protected bool serializeString(string str)
    {
        builder.Append("\"");

        char[] charArray = str.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            char currentChar = charArray[i];

            switch (currentChar)
            {
                case '"':
                    builder.Append("\\\"");
                    break;

                case '\\':
                    builder.Append("\\\\");
                    break;

                case '\b':
                    builder.Append("\\b");
                    break;

                case '\f':
                    builder.Append("\\f");
                    break;

                case '\r':
                    builder.Append("\\r");
                    break;

                case '\t':
                    builder.Append("\\t");
                    break;

                default:
                    int codepoint = Convert.ToInt32(currentChar);
                    if ((codepoint >= 32) && (codepoint <= 126))
                    {
                        builder.Append(currentChar);
                    }
                    else
                    {
                        builder.Append("\\u" + Convert.ToString(codepoint, 16).PadLeft(4, '0'));
                    }
                    break;
            }
        }

        builder.Append("\"");
        return true;
    }

    protected bool serializeNumber(double number)
    {
        builder.Append(number.ToString(CultureInfo.InvariantCulture));
        return true;
    }

    protected bool isNumeric(object value)
    {
        double result;
        return (value == null) ? false : Double.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out result);
    }
}