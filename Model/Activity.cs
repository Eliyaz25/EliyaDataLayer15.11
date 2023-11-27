using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Activity : BaseEntity
    {
        protected string activityName;
        protected string managerName;
        protected string operatorName;
        protected int numVolunnteers;
        protected DateTime dateActivity;
        protected City city;
        protected string location;
        protected DateTime startTime;
        protected DateTime endTime;
        protected ActivityType type;

        [DataMember]
        public string ActivityName { get { return activityName; } set { activityName = value; } }
        [DataMember]
        public string ManagerName { get { return managerName; } set { managerName = value; } }
        [DataMember]
        public string OperatorName { get { return operatorName; } set { operatorName = value; } }
        [DataMember]
        public int NumVolunnteers { get { return numVolunnteers; } set { numVolunnteers = value; } }
        [DataMember]
        public DateTime DateActivity { get { return dateActivity; } set { dateActivity = value; } }
        [DataMember]
        public City City { get { return city; } set { city = value; } }
        [DataMember]
        public string Location { get { return location; } set { location = value; } }
        [DataMember]
        public DateTime StartTime { get { return startTime; } set { startTime = value; } }
        [DataMember]
        public DateTime EndTime { get { return endTime; } set { endTime = value; } }
        [DataMember]
        public ActivityType Type { get { return type; } set { type = value; } }

    }

    [CollectionDataContract]
    public class ActivityList : List<Activity>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public ActivityList() { }

        //המרה אוסף גנרי לרשימת פעילויות
        public ActivityList(IEnumerable<Activity> list)
            : base(list) { }

        //המרה מטיפוס בסיס לרשימת פעילויות
        public ActivityList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Activity>().ToList()) { }

    }
}
