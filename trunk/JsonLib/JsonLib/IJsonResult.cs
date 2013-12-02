using System;
using System.Collections.Generic;
using System.Text;

public interface IJsonResult
{
    JsonObject ToObject();

    JsonArray ToArray();
}
