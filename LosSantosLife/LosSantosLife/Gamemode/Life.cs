using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using GTANetworkServer;
using LosSantosLife.Gamemode.Features;
using LosSantosLife.Gamemode.Library;
using LosSantosLife.Gamemode.Library.Specific;

namespace LosSantosLife.Gamemode
{
    /// <summary>
    /// The Los Santos Life main class.
    /// Contains methods that are important before anything else is loaded.
    /// </summary>
    public class Life : Script
    {
        /*
         _                _____             _            _      _  __     
        | |              / ____|           | |          | |    (_)/ _|
        | |     ___  ___| (___   __ _ _ __ | |_ ___  ___| |     _| |_ ___
        | |    / _ \/ __|\___ \ / _` | '_ \| __/ _ \/ __| |    | |  _/ _ \
        | |___| (_) \__ \____) | (_| | | | | || (_) \__ \ |____| | ||  __/
        |______\___/|___/_____/ \__,_|_| |_|\__\___/|___/______|_|_| \___|
        
        Los Santos Life
        Courtesy of the team and everyone else involved.
        
        Written with love by Kingstone (http://steamcommunity.com/id/ryankingstone/ - http://github.com/ryan-kingstone)
        
        ---------------------------------------------------------------------------------------------------------------

        "The only way to make sense out of change is to plunge into it, move with it, and join the dance."
        - Alan Watts
        */

        private bool AllowedStart { get; set; }

        public static LifeSettings LifeSettings { get; set; }

        public Life()
        {
            API.onResourceStart += API_onResourceStart;
            API.onResourceStop += API_onResourceStop;
        }

        private void API_onResourceStart()
        {
            var linkerTime = LinkerTime.GetLinkerTime(Assembly.GetExecutingAssembly());

            LifeSettings = LifeSettings.ReadSettings("life_config.xml");
            LifeLogging.Log("Loading the Life settings file.", LogType.Info);

            LifeLogging.Log("Starting the Los Santos Life server.", LogType.Info);
            LifeLogging.Log($"Server build time: {linkerTime}", LogType.Info);

            #region Database test
            var testResult = TestConnection();
            if (testResult)
            {
                LifeLogging.Log($"Database test successful.");
                AllowedStart = true;
            }
            else
            {
                LifeLogging.Log($"Database test failed.", LogType.Critical);
                LifeLogging.Log($"[WARNING ---- DATABASE FAILED TO CONNECT -- CHECK CONFIG]", LogType.Critical);
                LifeLogging.Log($"[WARNING ---- DATABASE FAILED TO CONNECT -- CHECK CONFIG]", LogType.Critical);
                LifeLogging.Log($"[WARNING ---- DATABASE FAILED TO CONNECT -- CHECK CONFIG]", LogType.Critical);
                API.stopResource("life");
                AllowedStart = false;
            }
            #endregion
        }

        private void API_onResourceStop()
        {
            LifeLogging.Log("Stopping the Los Santos Life server.", LogType.Info);
        }

        public bool TestConnection()
        {
            using (var db = new Database.Database())
            {
                DbConnection conn = db.Database.Connection;
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}