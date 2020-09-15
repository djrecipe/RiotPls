using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotPls.DataDragon;

namespace RiotPls.Test
{
    [TestClass]
    public class TestRawDataDragonQueries
    {
        [TestMethod]
        public void TestVersions()
        {
            string versions_url = @"https://ddragon.leagueoflegends.com/api/versions.json";
            HttpWebRequest request = HttpWebRequest.Create(versions_url ) as HttpWebRequest;
            string text = null;
            using (StreamReader stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                text = stream_reader.ReadToEnd();
                stream_reader.Close();
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            DataDragonVersionInfo info = JsonConvert.DeserializeObject<DataDragonVersionInfo>(text, settings);
            Assert.IsTrue(info.Count > 0, "Failed to retrieve any valid Data Dragon version strings");

            string current_version = info.CurrentVersion;
            Assert.IsNotNull(current_version, "Invalid current version");
            Console.WriteLine("Current version is {0}", current_version);
            return;
        }
    }
}
