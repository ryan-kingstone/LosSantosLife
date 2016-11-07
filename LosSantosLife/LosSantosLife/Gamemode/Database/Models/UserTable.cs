using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkServer;

/// <summary>
/// The users table holds the user variables and such.
/// </summary>
[Table("users")]
public class UserModel
{
    [Key]
    [Column("id")]
    public int UserId { get; set; }

    [Column("name", TypeName = "varchar")]
    public string UserName { get; set; }

    [Column("ip", TypeName = "varchar")]
    public string Ip { get; set; }

    [Column("password", TypeName = "varchar")]
    public string Password { get; set; }

    [Column("user_title", TypeName = "varchar")]
    public string UserTitle { get; set; }

    [Column("gang_id")]
    public int GangId { get; set; }

    [Column("flags", TypeName = "text")]
    public string Flags { get; set; }

    [Column("appearance", TypeName = "text")]
    public string Appearance { get; set; }

    [Column("inventory", TypeName = "text")]
    public string Inventory { get; set; }

    [Column("equipped", TypeName = "text")]
    public string Equipped { get; set; }

    [Column("jail_time")]
    public int JailTime { get; set; }

    [Column("money")]
    public int Money { get; set; }

    [Column("bank_money")]
    public int Bank { get; set; }

    [Column("kills")]
    public int Kills { get; set; }

    [Column("deaths")]
    public int Deaths { get; set; }

    [Column("licenses", TypeName = "text")]
    public int Licenses { get; set; }

    [Column("playtime")]
    public int Playtime { get; set; }

    [Column("admin_notes", TypeName = "text")]
    public int AdminNotes { get; set; }

    [NotMapped]
    public Client PlayerClient { get; set; }
}

public static class User
{
    public static List<UserModel> UserList = new List<UserModel>();

    public static UserModel GetPlayerData(Client player)
    {
        UserModel userModel = new UserModel();
        foreach (var user in UserList)
        {
            if (user.PlayerClient == player)
            {
                userModel = user;
            }
        }
        return userModel;
    }
}