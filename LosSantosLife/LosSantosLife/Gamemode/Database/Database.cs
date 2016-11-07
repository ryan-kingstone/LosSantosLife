using MySql.Data.Entity;
using System.Data.Entity;

/// <summary>
/// The database class is used to create the database models and relationships.
/// </summary>
[DbConfigurationType(typeof(MySqlEFConfiguration))]
public class Database : DbContext
{
    // Connect to the database using stored credentials (server.cfg)
    public Database() : base(
        $"data source={Config.GetKeyString("#server")};database={Config.GetKeyString("#database")};uid={Config.GetKeyString("#user")};pwd={Config.GetKeyString("#password")};"
        )
    { }
    // 

    public DbSet<UserModel> User { get; set; }
}