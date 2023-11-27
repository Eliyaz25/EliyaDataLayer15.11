using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ServiceModel
{
    public class ServiceProject : IServiceProject
    {
        //activity
        public ActivityList SelectAllActivity()
        {
            ActivityDB db = new ActivityDB();
            ActivityList list = db.SelectAllActivty();
            return list;
        }
        
        public int InsertActivity(Activity activity)
        {
            ActivityDB db = new ActivityDB();
            return db.InsertActivity(activity);
        }

        public int UpdateActivity(Activity activity)
        {
            ActivityDB db = new ActivityDB();
            return db.UpdateActivity(activity);
        }

        public int DeleteActivity(Activity activity)
        {
            ActivityDB db = new ActivityDB();
            return db.InsertActivity(activity);
        }

        //activityType
        public ActivityTypeList SelectAllActivityType()
        {
            ActivityTypeDB db = new ActivityTypeDB();
            ActivityTypeList list = db.SelectAllActivityType();
            return list;
        }

        public int InsertActivityType(ActivityType activityType)
        {
            ActivityTypeDB db = new ActivityTypeDB();
            return db.InsertActivityType(activityType);
        }

        public int UpdateActivityType(ActivityType activityType)
        {
            ActivityTypeDB db = new ActivityTypeDB();
            return db.UpdateActivityType(activityType);
        }

        public int DeleteActivityType(ActivityType activityType)
        {
            ActivityTypeDB db = new ActivityTypeDB();
            return db.InsertActivityType(activityType);
        }

        //city
        public CityList SelectAllCity()
        {
            CityDB db = new CityDB();
            CityList list = db.SelectAllCity();
            return list;
        }

        public int InsertCity(City city)
        {
            CityDB db = new CityDB();
            return db.InsertCity(city);
        }

        public int UpdateCity(City city)
        {
            CityDB db = new CityDB();
            return db.UpdateCity(city);
        }

        public int DeleteCity(City city)
        {
            CityDB db = new CityDB();
            return db.InsertCity(city);
        }

        //user
        public UserList SelectAllUser()
        {
            UserDB db = new UserDB();
            UserList list = db.SelectAllUser();
            return list;
        }

        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            return db.InsertUser(user);
        }

        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            return db.UpdateUser(user);
        }

        public int DeleteUser(User user)
        {
            UserDB db = new UserDB();
            return db.InsertUser(user);
        }

        public User Login(User user)
        {
            UserDB db = new UserDB();
            return db.Login(user);
        }
    }
}
