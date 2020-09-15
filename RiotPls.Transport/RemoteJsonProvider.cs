using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;

namespace RiotPls.Transport
{
    public class RemoteJsonProvider : IJsonProvider
    {
        public string GetText(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            string text = null;
            using (StreamReader stream_reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                text = stream_reader.ReadToEnd();
                stream_reader.Close();
            }
            return text;
        }
    }
}
