using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTest
{
    public static class JsonAssert
    {
        public static void Contains(string needle, string haystack)
        {
            Assert.IsTrue(haystack.Contains(needle));
        }
    }
}
