using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AlignTest
{
    class User
    {
        string path = "Path_To_Json";

        int Id;
        string username;
        string firstname;
        string lastname;
        string email;
        string password;
        string phone;
        int userStatus;
        public User(int Id, string username, string firstname, string lastname, string email, string password, string phone, int userStatus)
        {
            this.Id = Id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.userStatus = userStatus;
        }
        public void CreateUser(int Id, string username, string firstname, string lastname, string email, string password, string phone, int userStatus)
        {
            bool exist = false;
            if (email.Contains('@') && email.Contains('.') && email.EndsWith(".com"))
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
                foreach (User user in users)
                {
                    if (user.username == username)
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    User user = new User(Id, username, firstname, lastname, email, password, phone, userStatus);
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(user));
                }
            }
        }
        public void CreateUser(User user)
        {
            bool exist = false;
            if (user.email.Contains('@') && user.email.Contains('.') && user.email.EndsWith(".com"))
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
                foreach (User iUser in users)
                {
                    if (user.username == iUser.username)
                    {
                        exist = true;
                    }
                }
                if (!exist)
                {
                    User _user = new User(user.Id, user.username, user.firstname, user.lastname, user.email, user.password, user.phone, user.userStatus);
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(_user));
                }
            }
        }
        public void CreateWithArray(User[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                CreateUser(arr[i]);
            }
        }
        public void CreateWithList(List<User> users)
        {
            foreach (User user in users)
            {
                CreateUser(user);
            }
        }

        public bool Login(string username, string password)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
            foreach (User user in users)
            {
                if (user.username == username && user.password == password)
                {
                    user.userStatus = 1;
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(user));

                    return true;
                }
            }
            return false;
        }
        public void Logout (int id)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    user.userStatus = 0;
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(user));

                }
            }
        }

        public void UpdateUser(User _user)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].Id == _user.Id)
                {
                    users[i] = _user;
                    
                }
            }
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(users));
        }

        public void DeleteUser(string username)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(System.IO.File.ReadAllText(path));
            users.RemoveAll(user => user.username == username);
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(users));
        }
    }
}
