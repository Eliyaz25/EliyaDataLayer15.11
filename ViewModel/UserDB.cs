using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["ID"].ToString());
            user.FirstName = reader["firstName"].ToString();
            user.LastName = reader["lastName"].ToString();
            user.Username = reader["username"].ToString();
            user.Password = reader["password"].ToString();
            user.Email = reader["email"].ToString();
            user.Birthday = DateTime.Parse(reader["bDay"].ToString());
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.IsManager = bool.Parse(reader["isManager"].ToString());
            user.IsOperator = bool.Parse(reader["isOperator"].ToString());
            user.IsVolunteer = bool.Parse(reader["isVolunteer"].ToString());
            ActivityDB activityDB = new ActivityDB();
            user.Activities = activityDB.SelectByUser(user);
            CityDB cityDB = new CityDB();
            int cityID = int.Parse(reader["city"].ToString());
            user.City = cityDB.SelectById(cityID);
            return user;
        }


        public UserList SelectAllUser()
        {
            command.CommandText = "SELECT * FROM tblUser";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }

        public User SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE (ID = {id})";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", user.ID);
            command.Parameters.AddWithValue("@firstName", user.FirstName);
            command.Parameters.AddWithValue("@lastName", user.LastName);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@bDay", user.Birthday);
            command.Parameters.AddWithValue("@gender", user.Gender);
            command.Parameters.AddWithValue("@city", user.City.ID);
            command.Parameters.AddWithValue("@isManager", user.IsManager);
            command.Parameters.AddWithValue("@isOperator", user.IsOperator);
            command.Parameters.AddWithValue("@isVolunteer", user.IsVolunteer);

        }

        public int InsertUser(User user)
        {
            command.CommandText = "INSERT INTO tblUser (firstName, lastName, username, password, email, bDay, gender, city, isManager, isOperator, isVolunteer) VALUES (@firstName, @lastName, @username, @password, @email, @bDay, @gender, @city, @isManager, @isOperator, @isVolunteer)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int UpdateUser(User user)
        {
            command.CommandText = "UPDATE tblUser SET firstName= @firstName, lastName= @lastName, username= @username, password= @password, email= @email, bDay= @bDay, gender= @gender, city= @city, isManager= @isManager, isOperator= @isOperator, isVolunteer= @isVolunteer  WHERE ID = @ID";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int DeleteUser(User user)
        {
            command.CommandText = "DELETE FROM tblUser WHERE ID =@ID";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM tblUser WHERE username='{user.Username}' AND [password]='{user.Password}'";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
    }
}

