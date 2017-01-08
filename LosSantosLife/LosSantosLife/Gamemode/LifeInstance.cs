using System.Collections.Generic;
using GTANetworkServer;
using LosSantosLife.Gamemode.Database.Models;
using LosSantosLife.Gamemode.Managers;

namespace LosSantosLife.Gamemode
{
    public class LifeInstance : Script
    {
        // Users instance list
        public static List<UserModel> UserList = new List<UserModel>();

        public static List<Client> ActiveClients = new List<Client>();

        public LifeInstance()
        {
            API.onPlayerConnected += API_onPlayerConnected;
            API.onPlayerDisconnected += API_onPlayerDisconnected;
        }

        private void API_onPlayerConnected(Client player)
        {
            ActiveClients.Add(player);
            player.sendChatMessage("Welcome to ~p~Los Santos:Life~w~.");
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