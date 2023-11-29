using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {
        protected string firstName;
        protected string lastName;
        protected string username;
        protected string password;
        protected string email;
        protected DateTime bDay;
        protected bool gender;
        protected City city;
        protected bool isManager;
        protected bool isOperator;
        protected bool isVolunteer;


        [DataMember]
        public string FirstName { get { return firstName; } set { firstName = value; } }

        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }

        [DataMember]
        public string Username { get { return username; } set { username = value; } }

        [DataMember]
        public string Password { get { return password; } set { password = value; } }

        [DataMember]
        public string Email { get { return email; } set { email = value; } }

        [DataMember]
        public DateTime Birthday { get { return bDay; } set { bDay = value; } }

        [DataMember]
        public bool Gender { get { return gender; } set { gender = value; } }

        [DataMember]
        public City City { get { return city; } set { city = value; } }

        [DataMember]
        public bool IsManager { get { return isManager; } set { isManager = value; } }

        [DataMember]
        public bool IsOperator { get { return isOperator; } set { isOperator = value; } }

        [DataMember]
        public bool IsVolunteer { get { return isVolunteer; } set { isVolunteer = value; } }


    }

    [CollectionDataContract]
    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }

        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }

        //המרה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }

    }
}
