using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.Transport
{
    public class JsonDeserializer
    {
        public T Deserialize<T>(string text)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            T result = JsonConvert.DeserializeObject<T>(text, settings);
            return result;
        }
    }
}
