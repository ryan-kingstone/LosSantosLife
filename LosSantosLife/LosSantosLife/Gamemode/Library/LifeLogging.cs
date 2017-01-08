using System;

namespace LosSantosLife.Gamemode.Library
{
    public static class LifeLogging
    {
        /// <summary>
        /// Sends a default log, allowing you to choose colour.
        /// </summary>
        /// <param name="logText">log text</param>
        /// <param name="logType">ConsoleColor</param>
        public static void Log(string logText, LogType logType = LogType.Default)
        {
            switch (logType)
            {
                default: Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Default: Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Debug:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.LoggedDebug:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case LogType.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine("[LIFE] " + DateTime.Now + ": " + logText);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void LogException(string text)
        {
            var timestamp = DateTime.Now;
            Log(text, LogType.Critical);
        }
    }

    public enum LogType
    {
        Default,
        Info,
        Debug,
        LoggedDebug,
        Warning,
        Critical,
    }
}