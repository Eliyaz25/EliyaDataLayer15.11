using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ActivityTypeDB : BaseDB
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

        public ActivityTypeList SelectAllActivityType()
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

        public int InsertActivityType(ActivityType activityType)
        {
            command.CommandText = "INSERT INTO tblActivityType (type) VALUES (@type)";
            LoadParameters(activityType);
            return ExecuteCRUD();
        }
        public int UpdateActivityType(ActivityType activityType)
        {
            command.CommandText = "UPDATE tblActivityType SET type = @type WHERE ID = @ID";
            LoadParameters(activityType);
            return ExecuteCRUD();
        }
        public int DeleteActivityType(ActivityType activityType)
        {
            command.CommandText = "DELETE FROM tblActivityType WHERE ID =@ID";
            LoadParameters(activityType);
            return ExecuteCRUD();
        }
    }
}
