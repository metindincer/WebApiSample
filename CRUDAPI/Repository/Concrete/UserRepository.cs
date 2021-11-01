using CRUDAPI.Models;
using CRUDAPI.Repository.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        string jsonFile = @"C:\Users\metin\source\repos\CRUDAPI\CRUDAPI\Repository\Users.json";
        
        //Reads JsonFile before processes
        public List<User> GetUsersFromJson()
        {
            StreamReader r = new StreamReader(jsonFile);

            string json = r.ReadToEnd();

            r.Close();

            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        //Serialize strings to JsonFormat
        public void SerializeJson(List<User> userList)
        {
            string newJson = JsonConvert.SerializeObject(userList);
            File.WriteAllText(jsonFile, newJson);
        }
        public void AddUser(User user)
        {

            List<User> userList = GetUsersFromJson();


            User newuser = new User()
            {
                UserId = user.UserId,
                UserName = user.UserName,
               

            };
            userList.Add(newuser);
            SerializeJson(userList);
        }

        public List<User> GetAllUsers()
        {
            return GetUsersFromJson();
        }

        public User GetUserById(int id)
        {
            List<User> userList = GetUsersFromJson();

           
               
            return userList.Find(a => a.UserId == id);
        }

        public void RemoveUser(int id)
        {
            List<User> userList = GetUsersFromJson();
            //Finds user according to userId
            User user = userList.Find(a => a.UserId == id);
            
            userList.Remove(user);
            SerializeJson(userList);
        }

        public void UpdateUser(User user)
        {
            List<User> userList = GetUsersFromJson();
            //Finds olduser according to userId to change it
            User oldUser = userList.Find(a => a.UserId == user.UserId);
            //finds the index of olduser in list
            int index = userList.IndexOf(oldUser);
            //changes the oldUser with newUser
            userList[index]=user;
            SerializeJson(userList);
        }
    }
}
