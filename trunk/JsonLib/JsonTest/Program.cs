using System;
using System.Collections.Generic;
using System.Text;

namespace JsonTest
{
    class Program
    {
        static void testEncode(out string objJson, out string arrJson, out string strJson, out string dblJson, out string boolJson)
        {
            Console.WriteLine("JsonObject");
            var jsonObject = new JsonObject();
            jsonObject["param1"] = "value";
            jsonObject["param2"] = 2;
            jsonObject["param3"] = true;
            jsonObject["param4"] = 0.1;
            objJson = Json.Encode(jsonObject);
            Console.WriteLine(objJson + Environment.NewLine);

            Console.WriteLine("JsonArray");
            var jsonArray = new JsonArray();
            jsonArray.Add("value");
            jsonArray.Add(2);
            jsonArray.Add(true);
            jsonArray.Add(0.1);
            arrJson = Json.Encode(jsonArray);
            Console.WriteLine(arrJson + Environment.NewLine);

            Console.WriteLine("String");
            strJson = Json.Encode("value");
            Console.WriteLine(strJson + Environment.NewLine);

            Console.WriteLine("Double");
            dblJson = Json.Encode(0.1);
            Console.WriteLine(dblJson + Environment.NewLine);

            Console.WriteLine("Boolean");
            boolJson = Json.Encode(true);
            Console.WriteLine(boolJson + Environment.NewLine);
        }

        static void testDecode(string objJson, string arrJson, string strJson, string dblJson, string boolJson)
        {
            Console.WriteLine("JsonObject");
            var jsonObject = Json.Decode(objJson).ToObject();
            Console.WriteLine("param1: {0} | param2: {1} | param3: {2} | param4: {3}" + Environment.NewLine, jsonObject["param1"], jsonObject["param2"], jsonObject["param3"], jsonObject["param4"]);

            Console.WriteLine("JsonArray");
            var jsonArray = Json.Decode(arrJson).ToArray();
            Console.WriteLine("{0} | {1} | {2} | {3}" + Environment.NewLine, jsonArray[0], jsonArray[1], jsonArray[2], jsonArray[3]);

            Console.WriteLine("String");
            Console.WriteLine(Json.DecodeString(strJson) + Environment.NewLine);

            Console.WriteLine("Double");
            Console.WriteLine(Json.DecodeDouble(dblJson) + Environment.NewLine);

            Console.WriteLine("Boolean");
            Console.WriteLine(Json.DecodeBool(boolJson) + Environment.NewLine);
        }

        static void pause()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Json.STRICT = true;
            string objJson, arrJson, strJson, dblJson, boolJson;

            // Testing encode
            Console.WriteLine("Testing encode..." + Environment.NewLine);
            testEncode(out objJson, out arrJson, out strJson, out dblJson, out boolJson);
            pause();

            // Testing decode
            Console.WriteLine("Testing decode..." + Environment.NewLine);
            testDecode(objJson, arrJson, strJson, dblJson, boolJson);
            pause();
        }
    }
}
