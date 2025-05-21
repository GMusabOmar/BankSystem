using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsUser
    {
        public enum enTypeMode { Add = 0, Update = 1}
        private enTypeMode _Mode = enTypeMode.Add;
        public int UserID { get; set; }
        public int Person_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser()
        {
            this.UserID = -1;
            this.Person_ID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            _Mode = enTypeMode.Add;
        }
        public clsUser(int UserID, int Person_ID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.Person_ID = Person_ID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            _Mode = enTypeMode.Update;
        }
        public static clsUser FindUserByID(int UserID)
        {
            int Person_ID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool isFound = clsUserData.FindUserByID(UserID, ref Person_ID,
                            ref UserName, ref Password, ref IsActive);
            if (isFound)
                return new clsUser(UserID, Person_ID, UserName, Password, IsActive);
            return null;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.Person_ID, this.UserName,
                          this.Password, this.IsActive);
            return this.UserID > 0;
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.UserName,
                            this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enTypeMode.Add:
                    if (_AddNewUser())
                    {
                        _Mode = enTypeMode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return _UpdateUser();
            }
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static DataTable GetAllUser()
        {
            return clsUserData.GetAllUser();
        }
        public static bool IsExistsUser(int UserID)
        {
            return clsUserData.IsExistsUser(UserID);
        }
        public static bool IsExistsUserByFPerson_ID(int Person_ID)
        {
            return clsUserData.IsExistsUserByFPerson_ID(Person_ID);
        }
        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1, Person_ID = -1;
            bool IsActive = false;
            bool isFound = clsUserData.FindUserByUserNameAndPassword(UserName, Password,
                            ref UserID, ref Person_ID, ref IsActive);
            if (isFound)
                return new clsUser(UserID, Person_ID, UserName, Password, IsActive);
            return null;
        }
    }
}
