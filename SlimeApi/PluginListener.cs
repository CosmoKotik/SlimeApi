using SlimeApi.Entities;
using SlimeApi.Enums;
using SlimeApi.Tools;
using System.Numerics;

namespace SlimeApi
{
    public abstract class PluginListener
    {
        public static List<PluginEvent> CalledEvents = new List<PluginEvent>();

        public static List<Player> Players = new List<Player>();
        public static List<Entity> Entities = new List<Entity>();
        public static List<NPC> Npcs = new List<NPC>();

        public abstract void OnInit();
        public abstract void OnStop();
        public void OnTick() { }
        public void OnPlayerJoin(Player player) { }
        public void OnPlayerLeave(Player player) { }

        public object HandleEvent(string eventName, object[] args)
        {
            PluginMethods method = (PluginMethods)Enum.Parse(typeof(PluginMethods), eventName);
            object arg1 = new object();
            if (args != null)
                arg1 = args[0];
            
            switch (method)
            {
                case PluginMethods.OnInit:
                    OnInit(); 
                    break;
                case PluginMethods.OnStop:
                    OnStop();
                    break;

                case PluginMethods.AddPlayer:
                    Players.Add((Player)arg1);
                    break;
                case PluginMethods.RemovePlayer:
                    Players.RemoveAll(x => x.EntityID == ((Player)arg1).EntityID);
                    break;
                case PluginMethods.UpdatePlayer:
                    int index = Players.FindIndex(x => x.UUID == ((Player)arg1).UUID);
                    Players[index] = (Player)arg1;
                    break;

                case PluginMethods.AddEntity:
                    Entities.Add((Entity)arg1);
                    break;
                case PluginMethods.RemoveEntity:
                    Entities.RemoveAll(x => x.EntityID == ((Entity)arg1).EntityID);
                    break;
                case PluginMethods.UpdateEntity:
                    index = Entities.FindIndex(x => x.UUID == ((Entity)arg1).UUID);
                    Entities[index] = (Entity)arg1;
                    break;

                case PluginMethods.AddNpc:
                    Npcs.Add((NPC)arg1);
                    break;
                case PluginMethods.RemoveNpc:
                    Npcs.RemoveAll(x => x.EntityID == ((NPC)arg1).EntityID);
                    break;
                case PluginMethods.UpdateNpc:
                    index = Npcs.FindIndex(x => x.UUID == ((NPC)arg1).UUID);
                    Npcs[index] = (NPC)arg1;
                    break;

                case PluginMethods.GetPlayers:
                    return GetPlayers();
                case PluginMethods.GetEvents:
                    PluginEvent[] events = CalledEvents.ToArray();
                    CalledEvents.Clear();
                    return events;

                default:
                    return GetType().GetMethod(eventName).Invoke(this, args);
            }

            return null;
        }


        /*public void AddPlayer(Player player) 
        { 
            Players.Add(player); 
            AddEntity(player);
        }
        public void RemovePlayer(Player player) 
        { 
            Players.RemoveAll(x => x.UUID == player.UUID); 
            RemoveEntity(player);
        }
        public void UpdatePlayer(Player player)
        {
            int index = Players.FindIndex(x => x.UUID == player.UUID);
            Players[index] = player;

            UpdateEntity(player);
        }*/

        /*public void AddEntity(Entity entity) { Entities.Add(entity); }
        public void RemoveEntity(Entity entity) { Entities.RemoveAll(x => x.UUID == entity.UUID); }
        public void UpdateEntity(Entity entity)
        {
            int index = Entities.FindIndex(x => x.UUID == entity.UUID);
            Entities[index] = entity;
        }*/
/*        public void AddNpc(NPC npc) 
        {
            Logger.Error("addded npc");
            Npcs.Add(npc);
            AddEntity(npc);
        }
        public void RemoveNpc(NPC npc) 
        {
            Npcs.RemoveAll(x => x.UUID == npc.UUID);
            RemoveEntity(npc);
        }
        public void UpdateNpc(NPC npc)
        {
            int index = Npcs.FindIndex(x => x.UUID == npc.UUID);
            Npcs[index] = npc;

            UpdateEntity(npc);
        }*/


        public NPC CreateNPC(NPC npc)
        {
            PluginEventHandler.AddEvent("npc.create", npc);
            return npc;
        }
        public NPC RemoveNPC(NPC npc)
        {
            PluginEventHandler.AddEvent("npc.remove", npc.EntityID);
            return npc;
        }

        public Entity SpawnEntity(Entity entity)
        {
            PluginEventHandler.AddEvent("entity.spawn", entity);
            return entity;
        }
        public Entity DestroyEntity(Entity entity)
        {
            PluginEventHandler.AddEvent("entity.destroy", entity.EntityID);
            return entity;
        }

        public Player[] GetPlayers()
        {
            return Players.ToArray();
        }

        public NPC[] GetAllNpc()
        {
            return Npcs.FindAll(x => x.isNpc).ToArray();
        }

        /*public PluginEvent[] GetEvents()
        {
            PluginEvent[] events = CalledEvents.ToArray();
            CalledEvents.Clear();
            return events;
        }*/
    }
}
