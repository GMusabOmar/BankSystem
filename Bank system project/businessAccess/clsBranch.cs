using System;
using System.Data;
using DataAccess;

namespace businessAccess
{
    public class clsBranch
    {
        private enum _enTypeMode { Add = 0, Update = 1}
        private _enTypeMode _Mode = _enTypeMode.Add;
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public decimal Assets { get; set; }
        public clsBranch()
        {
            this.BranchID = -1;
            this.BranchName = "";
            this.BranchAddress = "";
            this.Assets = -1;
            _Mode = _enTypeMode.Add;
        }
        public clsBranch(int BranchID, string BranchName,
            string BranchAddress, decimal Assets)
        {
            this.BranchID = BranchID;
            this.BranchName = BranchName;
            this.BranchAddress = BranchAddress;
            this.Assets = Assets;
            _Mode = _enTypeMode.Update;
        }
        public static DataTable GetAllBranch()
        {
            return clsBranchData.GetAllBranch();
        }
        private bool _AddNewBranch()
        {
            this.BranchID = clsBranchData.AddNewBranch(this.BranchName,
                this.BranchAddress, this.Assets);
            return this.BranchID > 0;
        }
        private bool _UpdateBranch()
        {
            return clsBranchData.UpdateBranch(BranchID, BranchName,
                    BranchAddress, Assets);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case _enTypeMode.Add:
                    if (_AddNewBranch())
                    {
                        _Mode = _enTypeMode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return _UpdateBranch();
            }
        }
        public static bool DeleteBranch(int BranchID)
        {
            return clsBranchData.DeleteBranch(BranchID);
        }
        public static bool IsExistsBranch(int BranchID)
        {
            return clsBranchData.IsExistsBranch(BranchID);
        }
        public static clsBranch FindBranch(int BranchID)
        {
            string BranchName = "", BranchAddress = "";
            decimal Assets = -1;
            bool isFound = clsBranchData.FindBranch(BranchID, ref BranchName,
                                ref BranchAddress, ref Assets);
            if(isFound)
            {
                return new clsBranch(BranchID, BranchName,
                    BranchAddress, Assets);
            }
            return null;
        }
        public static clsBranch FindBranchByName(string BranchName)
        {
            int BranchID = 0;
            string BranchAddress = "";
            decimal Assets = -1;
            bool isFound = clsBranchData.FindBranchByName(BranchName, ref BranchID,
                            ref BranchAddress, ref Assets);
            if (isFound)
            {
                return new clsBranch(BranchID, BranchName,
                    BranchAddress, Assets);
            }
            return null;
        }
    }
}
