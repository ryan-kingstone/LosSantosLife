using System.IO;
using System.Xml.Serialization;

namespace LosSantosLife.Gamemode.Features
{
    [XmlRoot("config")]
    public class LifeSettings
    {
        // Production mode toggle
        [XmlElement("is_production")]
        public bool IsProduction { get; set; }

        // MySQL
        [XmlElement("mysql_host")]
        public string MySqlHost { get; set; }
        [XmlElement("mysql_user")]
        public string MySqlUser { get; set; }
        [XmlElement("mysql_password")]
        public string MySqlPassword { get; set; }
        [XmlElement("mysql_database")]
        public string MySqlDatabase { get; set; }

        public LifeSettings()
        {
            IsProduction = false;

            // Default mysql options
            MySqlHost = "localhost";
            MySqlUser = "user";
            MySqlPassword = "password";
            MySqlDatabase = "database";
        }
        public static LifeSettings ReadSettings(string path)
        {
            var ser = new XmlSerializer(typeof(LifeSettings));
            LifeSettings settings = null;
            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path)) settings = (LifeSettings)ser.Deserialize(stream);
                //using (var stream = new FileStream(path, File.Exists(path) ? FileMode.Truncate : FileMode.Create, FileAccess.ReadWrite)) ser.Serialize(stream, settings);
            }
            else
            {
                using (var stream = File.OpenWrite(path)) ser.Serialize(stream, settings = new LifeSettings());
            }
            return settings;
        }
        public static void WriteSettings(string path, LifeSettings lifeSettings)
        {
            var ser = new XmlSerializer(typeof(LifeSettings));
            LifeSettings settings = lifeSettings;
            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite)) ser.Serialize(stream, settings);
            }
            else
            {
                using (var stream = File.OpenWrite(path)) ser.Serialize(stream, new LifeSettings());
            }
        }
    }
}