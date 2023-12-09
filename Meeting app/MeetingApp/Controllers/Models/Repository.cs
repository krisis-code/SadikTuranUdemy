using System.Reflection.Metadata.Ecma335;

namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo() {Name="Ali",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
             _users.Add(new UserInfo() {Name="Enes",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
              _users.Add(new UserInfo() {Name="Ahmet",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
               _users.Add(new UserInfo() {Name="Niyazi",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
        }
        public static List<UserInfo> Users 
        {
            get{
                return _users;
            }
        }

         public static void CreateUser(UserInfo user) 
        {
           _users.Add(user);
        }

    }
}