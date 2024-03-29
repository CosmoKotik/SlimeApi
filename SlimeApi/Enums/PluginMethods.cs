﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeApi.Enums
{
    public enum PluginMethods
    {
        OnInit,
        OnStop,
        OnTick,

        OnPlayerJoin,
        OnPlayerLeave,

        AddPlayer,
        RemovePlayer,
        UpdatePlayer,

        AddEntity,
        RemoveEntity,
        UpdateEntity,

        AddNpc,
        RemoveNpc,
        UpdateNpc,

        GetPlayers,
        GetEvents
    }
}
