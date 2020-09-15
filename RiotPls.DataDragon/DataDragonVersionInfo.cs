using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotPls.DataDragon
{
    [JsonArray]
    public class DataDragonVersionInfo : List<string>
    {
        private string regexVersion=@"\d+[.]\d+[.]\d+";
        public string CurrentVersion { private set; get;}
        public List<string> OtherVersions { private set; get; }
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            this.OtherVersions = new List<string>(this.Where(s => !Regex.IsMatch(s, regexVersion)));
            this.OtherVersions.Sort();

            IEnumerable<string> valid_versions = new List<string>(this.Where(s => Regex.IsMatch(s, regexVersion)));
            IOrderedEnumerable<string> values = valid_versions.OrderBy(s => Version.Parse(s));
            this.Clear();
            if(values.Count() > 0)
                this.AddRange(values);
            this.CurrentVersion = this.LastOrDefault();
            return;
        }
    }
}
