using GTANetworkServer;
using LosSantosLife.Gamemode.Library;

namespace LosSantosLife.Gamemode.Managers
{
    public class AccountManager : Script
    {
        //public API API = new API();

        public delegate void AccountEvent(Client player);
        public static event AccountEvent OnAccountLogin;

        public AccountManager()
        {
            LifeLogging.Log("Initializing AccountManager", LogType.Info);
        }

        [Command("login")]
        public void LoginCommand(Client player, string username, string password)
        {
            if (LifeAuthentication.AuthenticateUser(player, username, password))
            {
                OnAccountLogin?.Invoke(player);
                LifeLogging.Log($"{player.name} logged in successfully.");
            }
            else
            {
                // 3 password attempt kick:
            }
        }

        [Command("register")]
        public void RegisterCommand(Client player, string username, string password)
        {
            LifeAuthentication.RegisterUser(player, username, password);
        }

        [Command("test")]
        public void LoginTestCommand(Client player)
        {
            player.sendChatMessage("Test command works.");
        }
    }
}