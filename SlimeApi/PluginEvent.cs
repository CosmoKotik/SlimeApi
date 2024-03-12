using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeApi
{
    public class PluginEvent
    {
        public string EventName { get; set; }
        public object EventObject { get; set; }
    }
}
