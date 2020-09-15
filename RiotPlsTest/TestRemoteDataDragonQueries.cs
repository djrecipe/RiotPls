using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotPls.DataDragon.Remote;
using RiotPls.Transport;

namespace RiotPls.Test
{
    [TestClass]
    public class TestRemoteDataDragonQueries
    {
        private RemoteJsonProvider provider = null;
        private JsonDeserializer deserializer = null;
        [TestInitialize]
        public void InitializeTest()
        {
            this.provider = new RemoteJsonProvider();
            this.deserializer = new JsonDeserializer();
        }

        [TestMethod]
        public void TestVersions()
        {
            string text = this.provider.GetText(@"https://ddragon.leagueoflegends.com/api/versions.json");
            DataDragonVersionsInfo info = this.deserializer.Deserialize<DataDragonVersionsInfo>(text); 

            Assert.IsTrue(info.Count > 0, "Failed to retrieve any valid Data Dragon version strings");

            string current_version = info.CurrentVersion;
            Assert.IsNotNull(current_version, "Invalid current version");
            Console.WriteLine("Current version is {0}", current_version);
            return;
        }
        [TestMethod]
        public void TestRealms()
        {
            string text = this.provider.GetText(@"https://ddragon.leagueoflegends.com/realms/na.json");
            DataDragonRealmInfo info = this.deserializer.Deserialize<DataDragonRealmInfo>(text);

            string cdn_url = info.ContentURL;
            Assert.IsNotNull(cdn_url, "Invalid CDN URL");

            Console.WriteLine("CDN URL is {0}", cdn_url);
        }
    }
}
