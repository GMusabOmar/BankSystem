using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsCustomer
    {
        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; } 
        public string SecondName { get; set; } 
        public string ThirdName { get; set; }
        public string LastName{ get; set; } 
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; } 
        public int AccountID{ get; set; } 
        public int CreditCardID { get; set; }
        public clsPeron PersonInfo;
        public clsCustomer()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.FirstName = null;
            this.SecondName = null;
            this.ThirdName = null;
            this.LastName = null;
            this.Email = null;
            this.Address = null;
            this.Phone = null;
            this.AccountID = -1;
            this.CreditCardID = -1;
        }
        public clsCustomer(int CustomerID, int PersonID, string FirstName,
            string SecondName, string ThirdName, string LastName,
            string Email, string Address, string Phone, int AccountID,
            int CreditCardID)
        {
            this.CustomerID = CustomerID;
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
            this.AccountID = AccountID;
            this.CreditCardID = CreditCardID;
            this.PersonInfo = clsPeron.FindPerson(this.PersonID);
        }
        public static clsCustomer FindCustomerByID(int CustomerID)
        {
            int PersonID = -1;
            string FirstName = null, SecondName = null, ThirdName = null,
                   LastName = null, Email = null, Address = null, Phone = null;
            int AccountID = -1, CreditCardID = -1;
            bool isFound = clsCustomerData.FindCustomerByID(CustomerID, ref PersonID,
                            ref FirstName, ref SecondName, ref ThirdName,
                            ref LastName, ref Email, 
                            ref Address, ref Phone, ref AccountID, ref CreditCardID);
            if(isFound)
            {
                return new clsCustomer(CustomerID, PersonID, FirstName,
                                        SecondName, ThirdName, LastName,
                                        Email, Address, Phone, AccountID,
                                        CreditCardID);
            }
            return null;
        }
        public static clsCustomer FindCustomerByPersonID(int PersonID)
        {
            int CustomerID = -1;
            string FirstName = null, SecondName = null, ThirdName = null,
                   LastName = null, Email = null, Address = null, Phone = null;
            int AccountID = -1, CreditCardID = -1;
            bool isFound = clsCustomerData.FindCustomerByPersonID(PersonID, ref CustomerID,
                            ref FirstName, ref SecondName, ref ThirdName,
                            ref LastName, ref Email,
                            ref Address, ref Phone, ref AccountID, ref CreditCardID);
            if (isFound)
            {
                return new clsCustomer(CustomerID, PersonID, FirstName,
                                        SecondName, ThirdName, LastName,
                                        Email, Address, Phone, AccountID,
                                        CreditCardID);
            }
            return null;
        }
        public static DataTable GetAllCustomer()
        {
            return clsCustomerData.GetAllCustomer();
        }
        public bool AddNewCustomer(int PersonID)
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(PersonID);
            return this.CustomerID > 0;
        }
        public static bool DeleteCustomer(int PersonID)
        {
            return clsCustomerData.DeleteCustomer(PersonID);
        }
        public static bool IsExistsCustomerByFPerson_ID(int CustomerID)
        {
            return clsCustomerData.IsExistsCustomerByFPerson_ID(CustomerID);
        }
        public static bool IsExistsCustomerByID(int CustomerID)
        {
            return clsCustomerData.IsExistsCustomerByID(CustomerID);
        }
        public static clsCustomer FindCustomerByName(string FirstName, string SecondName,
            string ThirdName, string LastName)
        {
            int CustomerID = -1, PersonID = -1;
            string Email = null, Address = null, Phone = null;
            int AccountID = -1, CreditCardID = -1;
            bool isFound = clsCustomerData.FindCustomerByName(FirstName, SecondName,
                            ThirdName, LastName, ref PersonID, ref CustomerID,
                            ref Email, ref Address, ref Phone,
                            ref AccountID, ref CreditCardID);
            if (isFound)
            {
                return new clsCustomer(CustomerID, PersonID, FirstName,
                                        SecondName, ThirdName, LastName,
                                        Email, Address, Phone, AccountID,
                                        CreditCardID);
            }
            return null;
        }

    }
}
