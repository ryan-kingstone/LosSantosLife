using System.Collections.Generic;
using GTANetworkServer;

namespace LosSantosLife.Gamemode
{
    public class LifeInstance
    {
        private API LifeApi { get; set; }

        // Users instance list
        public static List<UserModel> UserList = new List<UserModel>();

        public static List<Client> ActiveClients = new List<Client>();

        public LifeInstance(API api)
        {
            LifeApi = api;

            LifeApi.onPlayerConnected += API_onPlayerConnected;
            LifeApi.onPlayerDisconnected += API_onPlayerDisconnected;
        }

        private void API_onPlayerConnected(Client player)
        {
            ActiveClients.Add(player);
        }

        private void API_onPlayerDisconnected(Client player, string reason)
        {
            if (ActiveClients.Contains(player))
            {
                ActiveClients.Remove(player);
            }
        }
    }
}