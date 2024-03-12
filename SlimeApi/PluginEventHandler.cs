using SlimeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeApi
{
    public class PluginEventHandler
    {
        public static void AddEvent(string eventName, object obj)
        {
            PluginEvent pevent = new PluginEvent();

            pevent = new PluginEvent()
            {
                EventName = eventName,
                EventObject = obj
            };

            PluginListener.CalledEvents.Add(pevent);
        }
    }
}
