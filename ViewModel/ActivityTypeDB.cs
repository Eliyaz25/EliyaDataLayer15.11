using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class ActivityTypeDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ActivityType activityType = entity as ActivityType;
            activityType.ID = int.Parse(reader["ID"].ToString());
            activityType.Type = reader["Type"].ToString();
            return activityType;
        }

        protected override BaseEntity NewEntity()
        {
            return new ActivityType();
        }

        public ActivityTypeList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblActivityType";
            ActivityTypeList list = new ActivityTypeList(ExecuteCommand());
            return list;
        }

        public ActivityType SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblActivityType WHERE ID={id}";
            ActivityTypeList list = new ActivityTypeList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            ActivityType activityType = entity as ActivityType;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", activityType.ID);
            command.Parameters.AddWithValue("@type", activityType.Type);
            
        }

        public int Insert(ActivityType activityType)
        {
            command.CommandText = "INSERT INTO tblActivityType (type) VALUES (@type)";
            LoadParameters(activityType);
            return ExecuteCRUD();
        }
        //public int Update(City city)
        //{
        //    command.CommandText = "UPDATE TblCity SET CityName = @CityName WHERE ID = @ID";
        //    LoadParameters(city);
        //    return ExecuteCRUD();
        //}
        //public int Delete(City city)
        //{
        //    command.CommandText = "DELETE FROM TblCity WHERE ID =@ID";
        //    LoadParameters(city);
        //    return ExecuteCRUD();
        //}
    }
}
