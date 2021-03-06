﻿using System.Data.Entity;
using LosSantosLife.Gamemode.Database.Models;
using MySql.Data.Entity;

namespace LosSantosLife.Gamemode.Database
{
    /// <summary>
    /// The database class is used to create the database models and relationships.
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Database : DbContext
    {
        // Connect to the database using stored credentials (server.cfg)
        public Database() : base($"data source={Life.LifeSettings.MySqlHost};database={Life.LifeSettings.MySqlDatabase};uid={Life.LifeSettings.MySqlUser};pwd={Life.LifeSettings.MySqlPassword};Convert Zero Datetime=True;Allow Zero Datetime=True")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<UserModel> User { get; set; }
    }
}