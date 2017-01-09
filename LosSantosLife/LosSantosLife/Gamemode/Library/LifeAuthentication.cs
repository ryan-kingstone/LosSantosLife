using System;
using System.Data.Entity;
using System.Linq;
using DevOne.Security.Cryptography.BCrypt;
using GTANetworkServer;
using LosSantosLife.Gamemode.Database.Models;

namespace LosSantosLife.Gamemode.Library
{
    public static class LifeAuthentication
    {
        private static readonly bool CanMultiAccount = Life.LifeSettings.CanMultiAccount;

        public static bool AuthenticateUser(Client requestClient, string username, string password)
        {
            if (requestClient.IsNull) return false;

            if (requestClient.hasSyncedData("logged_in"))
            {
                requestClient.sendChatMessage("You can't do this when you're already logged in.");
                return false;
            }

            using (var database = new Database.Database())
            {
                var userQuery = (from user in database.User
                                where user.UserName == username
                                select user).AsNoTracking().FirstOrDefault();

                if (userQuery != null)
                {
                    if (BCryptHelper.CheckPassword(password, userQuery.Password))
                    {
                        return true;
                    }
                    else
                    {
                        requestClient.sendChatMessage("~r~The username or password was incorrect.");
                        return false;
                    }
                }
                else
                {
                    requestClient.sendChatMessage("~r~No valid user was found.");
                    return false;
                }
            }
        }

        public static void RegisterUser(Client requestClient, string username, string password)
        {
            // Contingency check
            if (requestClient.IsNull)
            {
                LifeLogging.Log("Client was invalid when trying to use register");
                return;
            }

            if (requestClient.hasSyncedData("logged_in"))
            {
                requestClient.sendChatMessage("You can't do this when you're already logged in.");
                return;
            }

            // Ensure password and username conditions are met
            if (username.Length >= 3)
            {
                if (password.Length >= 5)
                {
                    try
                    {
                        if (!CanMultiAccount)
                        {
                            // ... run check to ensure no two users are the same
                        }

                        using (var database = new Database.Database())
                        {
                            // Generate a random bcrypt-safe salt
                            string passwordSalt = BCryptHelper.GenerateSalt();

                            // Create a new user model for insertion into the database
                            var user = new UserModel
                            {
                                UserName = username,
                                Password = BCryptHelper.HashPassword(password, passwordSalt),
                                Ip = requestClient.address,
                                // Set the default user title
                                UserTitle = "",
                                Licenses = "[]",
                                Flags = "[]",
                                Appearance = "[]",
                                Inventory = "[]",
                                Equipped = "[]",
                                // Give the user the default money and bank amounts
                                Money = 10000,
                                Bank = 15000,
                                AdminNotes = "",
                                // Set the date time fields
                                LastLogin = DateTime.Now,
                                CreatedAt = DateTime.Now,
                                LastUpdated = DateTime.Now
                            };

                            // Add the user to the database
                            database.User.Add(user);
                            database.Entry(user).State = System.Data.Entity.EntityState.Added;
                            database.SaveChanges();

                            requestClient.sendChatMessage($"Your user ~b~{username}~w~ has been registered. Use ~r~/login [username] [password]~w~ to login to the account.");
                        }
                    }
                    catch (Exception ex)
                    {
                        LifeLogging.LogException("Exception in LifeAuthentication.RegisterUser: " + ex);
                    } 
                } else requestClient.sendChatMessage("~r~Your password must be more than 5 characters long.");
            } else requestClient.sendChatMessage("~r~Your username must be more than 3 characters long.");
        }
    }
}