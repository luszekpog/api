using System.Collections.Generic;

namespace CryptoAPI.Modules
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() {UserName = "lucas_admin", EmailAdress = "lukasz.cal@onet.pl", Password = "qwerty1!",
            GivenName="Lucas", Surname="Cal", Role="Administrator"},
            new User() {UserName = "damian_moderator", EmailAdress = "damianeq.wal@interia.pl", Password="damian123!",
            GivenName =  "Damian", Surname ="Walania", Role="Moderator"}
        };
    }
}
