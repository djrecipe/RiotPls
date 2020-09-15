using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotPls.Transport
{
    interface IJsonProvider
    {
        string GetText(string path);
    }
}
