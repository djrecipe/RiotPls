﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.DataDragon.Content
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ChampionInfo
    {
        [JsonProperty("name")]
        public string Name { get; private set; } = null;
    }
}
