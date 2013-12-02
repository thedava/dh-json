using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class JsonArray : ArrayList, IJsonResult
{
    public int? GetInt(int index)
    {
        return Caster.ParseInt(this[index], index);
    }

    public double? GetDouble(int index)
    {
        return Caster.ParseDouble(this[index], index);
    }

    public bool? GetBool(int index)
    {
        return Caster.ParseBool(this[index], index);
    }

    public string GetString(int index)
    {
        return Caster.ParseString(this[index]);
    }

    public JsonObject GetObject(int index)
    {
        return Caster.ParseObject(this[index], index);
    }

    public JsonArray GetArray(int index)
    {
        return Caster.ParseArray(this[index], index);
    }

    public JsonObject ToObject()
    {
        throw new InvalidCastException("You can't cast a JsonArray to JsonObject!");
    }

    public new JsonArray ToArray()
    {
        return this;
    }
}
