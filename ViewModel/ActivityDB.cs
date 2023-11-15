﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class ActivityDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Activity activity = entity as Activity;
            activity.ID = int.Parse(reader["ID"].ToString());
            activity.ActivityName = reader["activityName"].ToString();
            activity.ManagerName = reader["managerName"].ToString();
            activity.OperatorName = reader["operatorName"].ToString();
            activity.NumVolunnteers = int.Parse(reader["numVolaunteers"].ToString());
            activity.DateActivity = DateTime.Parse(reader["dateActivity"].ToString());
            CityDB cityDB = new CityDB();
            int cityID = int.Parse(reader["city"].ToString());
            activity.Location = reader["location"].ToString();
            activity.StartTime = DateTime.Parse(reader["startTime"].ToString());
            activity.EndTime = DateTime.Parse(reader["endTime"].ToString());
            ActivityTypeDB activityTypeDB = new ActivityTypeDB();
            int activityTypeID = int.Parse(reader["type"].ToString());
            activity.Type = activityTypeDB.SelectById(activityTypeID);
            return activity;
        }

        protected override BaseEntity NewEntity()
        {
            return new Activity();
        }

        public ActivityList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblActivity";
            ActivityList list = new ActivityList(ExecuteCommand());
            return list;
        }

        public Activity SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblActivity WHERE (ID = {id})";
            ActivityList list = new ActivityList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public ActivityList SelectByUser(User user)
        {
            command.CommandText = $"SELECT tblActivity.* " +
                $"FROM (tblRegister INNER JOIN tblActivity ON tblRegister.activity = tblActivity.ID) " +
                $"WHERE (tblRegister.volunteer = {user.ID})";
            ActivityList list = new ActivityList(ExecuteCommand());
            return list;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Activity activity = entity as Activity;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", activity.ID);
            command.Parameters.AddWithValue("@activityName", activity.ActivityName);
            command.Parameters.AddWithValue("@managerName", activity.ManagerName);
            command.Parameters.AddWithValue("@operatorName", activity.OperatorName);
            command.Parameters.AddWithValue("@numVolunteers", activity.NumVolunnteers);
            command.Parameters.AddWithValue("@dateActivity", activity.DateActivity);
            command.Parameters.AddWithValue("@city", activity.City);
            command.Parameters.AddWithValue("@location", activity.Location);
            command.Parameters.AddWithValue("@startTime", activity.StartTime);
            command.Parameters.AddWithValue("@endTime", activity.EndTime);
            command.Parameters.AddWithValue("@type", activity.Type);
        }

        public int Insert(Activity activity)
        {
            command.CommandText = "INSERT INTO tblActivity (activityName, managerName, operatorName, numVolunteer, dateActivity, city, location, startTime, endTime, type) VALUES (@activityName, @managerName, @operatorName, @numVolunteer, @dateActivity, @city, @location, @startTime, @endTime, @type)";
            LoadParameters(activity);
            return ExecuteCRUD();
        }
        //public int Update(City city)
        //{
        //    command.CommandText = "UPDATE tblCity SET cityName = @cityName WHERE ID = @ID";
        //    LoadParameters(city);
        //    return ExecuteCRUD();
        //}
        //public int Delete(City city)
        //{
        //    command.CommandText = "DELETE FROM tblCity WHERE ID =@ID";
        //    LoadParameters(city);
        //    return ExecuteCRUD();
        //}
    }
}