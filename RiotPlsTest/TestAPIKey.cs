using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotPls.API;

namespace RiotPls.Test
{
    [TestClass]
    public class TestAPIKey
    {
        [TestMethod]
        public void TestEmptyAPIKeyInvalidPath()
        {
            string test_invalid_path = @"C:\123456\789\api.key";
            APIKey key = new APIKey(test_invalid_path);
            bool result =  key.Load();
            Assert.IsFalse(result, "Invalid result when trying to load API key from non-existant path (expected false)");
        }

    }
}
