using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ServiceModel;

namespace ServiceModel
{
    [ServiceContract]
    public interface IServiceProject
    {
        //activity
        [OperationContract] ActivityList SelectAllActivity();
        [OperationContract] int InsertActivity(Activity activity);
        [OperationContract] int UpdateActivity(Activity activity);
        [OperationContract] int DeleteActivity(Activity activity);

        //activityType
        [OperationContract] ActivityTypeList SelectAllActivityType();
        [OperationContract] int InsertActivityType(ActivityType activityType);
        [OperationContract] int UpdateActivityType(ActivityType activityType);
        [OperationContract] int DeleteActivityType(ActivityType activityType);

        //city
        [OperationContract] CityList SelectAllCity();
        [OperationContract] int InsertCity(City city);
        [OperationContract] int UpdateCity(City city);
        [OperationContract] int DeleteCity(City city);

        //user
        [OperationContract] UserList SelectAllUser();
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] User Login(User user);

    }
}
