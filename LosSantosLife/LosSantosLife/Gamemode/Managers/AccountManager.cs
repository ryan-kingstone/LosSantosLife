using GTANetworkServer;
using DevOne.Security.Cryptography.BCrypt;

public class AccountManager : Script
{
    public delegate void AccountEvent(Client player);
    public static event AccountEvent OnAccountLogin;
    public static event AccountEvent OnAccountDisconnectPreDataCleanup;

    public AccountManager()
    {
        
    }

    [Command("login")]
    public void LoginCommand(Client player, string user, string password)
    {
        var charData = User.GetPlayerData(player);
        if (charData.PlayerClient != null)
        {
            API.sendChatMessageToPlayer(player, $"~r~Error:~w~ You're already logged in");
        }
    }
}