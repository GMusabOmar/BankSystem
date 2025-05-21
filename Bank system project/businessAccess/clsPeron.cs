using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsPeron
    {
        public enum enTypeMode { Add = 0, Update = 1 }
        private enTypeMode _Mode = enTypeMode.Add;
        public int PersonID { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " +
                    ThirdName + " " + LastName;
            }
        }
        public string FirstName {  get; set; }
        public string SecondName {  get; set; }
        public string ThirdName {  get; set; }
        public string LastName {  get; set; }
        public string Email {  get; set; }
        public string Address {  get; set; }
        public string Phone {  get; set; }
        public clsPeron()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Address = "";
            this.Phone = "";
            _Mode = enTypeMode.Add;
        }
        public clsPeron(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string Email, string Address, string Phone)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
            _Mode = enTypeMode.Update;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPeronData.AddNewPerson(FirstName, SecondName,
            ThirdName, LastName, Email, Address, Phone);
            return this.PersonID > 0;
        }
        private bool _UpdatePerson()
        {
            return clsPeronData.UpdatePerson(PersonID, FirstName, SecondName,
            ThirdName, LastName, Email, Address, Phone);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enTypeMode.Add:
                    if (_AddNewPerson())
                    {
                        _Mode = enTypeMode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return _UpdatePerson();
            }
        }
        public static DataTable GetAllPerson()
        {
            return clsPeronData.GetAllPerson();
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPeronData.DeletePerson(PersonID);
        }
        public static bool IsExistsPerson(int PersonID)
        {
            return clsPeronData.IsExistsPerson(PersonID);
        }
        public static clsPeron FindPerson(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "",
            LastName = "", Email = "", Address = "", Phone = "";
            bool isFound = clsPeronData.FoundPerson(PersonID, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref Email, ref Address, ref Phone);
            if (isFound)
                return new clsPeron(PersonID, FirstName, SecondName, ThirdName,
                        LastName, Email, Address, Phone);
            else
                return null;
        }
    }
}
