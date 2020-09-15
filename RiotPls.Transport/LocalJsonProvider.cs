using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace RiotPls.Transport
{
    public class LocalJsonProvider : IJsonProvider
    {
        public string GetText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
