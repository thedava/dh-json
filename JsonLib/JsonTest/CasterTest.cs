using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JsonTest
{
    [TestClass]
    public class CasterTest
    {
        [TestMethod]
        public void TestParseInt_ValidValue()
        {
            Json.STRICT = false;
            int? result = Caster.ParseInt("12", null);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(12, result.Value);
        }

        [TestMethod]
        public void TestParseInt_InvalidValue_Strict()
        {
            Json.STRICT = true;
            try
            {
                int? result = Caster.ParseInt("Twelve", null);
                Assert.Fail("Expected Exception missing!");
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidCastException);
                JsonAssert.Contains("Int32", error.Message);
            }
        }

        [TestMethod]
        public void TestParseInt_InvalidValue_NotStrict()
        {
            Json.STRICT = false;
            int? result = Caster.ParseInt("Twelve", null);
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        public void TestParseString()
        {
            string result = Caster.ParseString(new CasterTest());
            Assert.AreEqual(result, "JsonTest.CasterTest");
        }

        [TestMethod]
        public void TestParseDouble_ValidValue()
        {
            Json.STRICT = true;
            double? result;

            // Point value
            result = Caster.ParseDouble("12.5", null);
            Assert.IsTrue(result.HasValue, "Point value conversion failed!");
            Assert.AreEqual(12.5, result.Value, "Point value conversion failed!");

            // Comma value
            result = Caster.ParseDouble("12,5", null);
            Assert.IsTrue(result.HasValue, "Comma value conversion failed!");
            Assert.AreEqual(12.5, result.Value, "Comma value conversion failed!");
        }

        [TestMethod]
        public void TestParseDouble_InvalidValue_Strict()
        {
            Json.STRICT = true;
            try
            {
                double? result = Caster.ParseDouble("Twelve and a half", null);
                Assert.Fail("Expected Exception missing!");
            }
            catch (Exception error)
            {
                Assert.IsTrue(error is InvalidCastException);
                JsonAssert.Contains("Double", error.Message);
            }
        }

        [TestMethod]
        public void TestParseDouble_InvalidValue_NotStrict()
        {
            Json.STRICT = false;
            double? result = Caster.ParseDouble("Twelve and a half", null);
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        public void TestParseBoolean_ValidValue()
        {
            Json.STRICT = false;
            bool? result;
            var values = new Dictionary<object, bool>();
            values.Add("True", true);
            values.Add("true", true);
            values.Add("TRUE", true);
            values.Add("False", false);
            values.Add("false", false);
            values.Add("FALSE", false);

            foreach (KeyValuePair<object, bool> value in values)
            {
                result = Caster.ParseBool(value.Key, null);
                Assert.IsTrue(result.HasValue, "Boolean value conversion of '" + value.Key + "' failed!");
                Assert.AreEqual(value.Value, result.Value, "Boolean value conversion of '" + value.Key + "' failed!");
            }
        }
    }
}
