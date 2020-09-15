using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.DataDragon.Remote
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DataDragonRealmInfo
    {
        [JsonProperty("cdn")]
        public string ContentURL { get; private set;} = null;
    }
}
