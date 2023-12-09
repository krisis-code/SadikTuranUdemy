using System.Reflection.Metadata.Ecma335;

namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo() {id = 1, Name="Ali",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
             _users.Add(new UserInfo() {id = 2,Name="Enes",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
              _users.Add(new UserInfo() {id = 3,Name="Ahmet",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
               _users.Add(new UserInfo() {id = 4,Name="Niyazi",Email="Abc@hotmail.com",Phone="111111",WillAttend=true});
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