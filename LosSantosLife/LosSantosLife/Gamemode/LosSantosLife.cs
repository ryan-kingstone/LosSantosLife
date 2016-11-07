using System;
using System.Reflection;
using GTANetworkServer;

/// <summary>
/// The Los Santos Life main class.
/// Contains methods that are important before anything else is loaded.
/// </summary>
public class LosSantosLife : Script
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

    public LosSantosLife()
    {
        API.onResourceStart += API_onResourceStart;
        API.onResourceStop += API_onResourceStop;
    }

    private void API_onResourceStart()
    {
        var linkerTime = LinkerTime.GetLinkerTime(Assembly.GetExecutingAssembly());

        LifeLogging.Log("Starting the Los Santos Life server.", LogType.Info);
        LifeLogging.Log($"Server build time: {linkerTime}", LogType.Info);
    }

    private void API_onResourceStop()
    {
        LifeLogging.Log("Stopping the Los Santos Life server.", LogType.Info);
    }
}