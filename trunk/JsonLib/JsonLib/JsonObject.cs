using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class JsonObject : Hashtable, IJsonResult
{
    public int? GetInt(object field)
    {
        return Caster.ParseInt(this[field], field);
    }

    public double? GetDouble(object field)
    {
        return Caster.ParseDouble(this[field], field);
    }

    public bool? GetBool(object field)
    {
        return Caster.ParseBool(this[field], field);
    }

    public string GetString(object field)
    {
        return Caster.ParseString(this[field]);
    }

    public JsonObject GetObject(object field)
    {
        return Caster.ParseObject(this[field], field);
    }

    public JsonArray GetArray(object field)
    {
        return Caster.ParseArray(this[field], field);
    }

    public JsonObject ToObject()
    {
        return this;
    }

    public JsonArray ToArray()
    {
        throw new InvalidCastException("You can't cast a JsonObject to JsonArray!");
    }
}