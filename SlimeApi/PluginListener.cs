using SlimeApi.Entity;

namespace SlimeApi
{
    public abstract class PluginListener
    {
        public static List<Player> Players = new List<Player>();

        public abstract void OnInit();
        public abstract void OnStop();
        public void OnTick() { }

        public void AddPlayer(Player player) { Players.Add(player); }
        public void RemovePlayer(Player player) { Players.RemoveAll(x => x.UUID == player.UUID); }
        public void UpdatePlayer(Player player)
        {
            int index = Players.FindIndex(x => x.UUID == player.UUID);
            Players[index] = player;
        }
        public Player[] GetPlayers()
        {
            Players.Add(new Player() { Username = "xuy", UUID = new Guid() });
            return Players.ToArray();
        }
    }
}
