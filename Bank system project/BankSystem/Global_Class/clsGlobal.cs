using businessAccess;
using Microsoft.Win32;


namespace BankSystem.Global_Class
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        public static bool SaveCredential(string UserName, string Password)
        {
            string Key = @"SOFTWARE\BankSystem";
            string svUserName = "UserName";
            string svPassword = "Password";
            try
            {
                using(RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(Key, true))
                {
                    if (RegKey != null)
                    {
                        if (UserName == "")
                        {
                            RegKey.DeleteValue(svUserName);
                            RegKey.DeleteValue(svPassword);
                        }
                        else
                        {
                            RegKey.SetValue(svUserName, UserName, RegistryValueKind.String);
                            RegKey.SetValue(svPassword, Password, RegistryValueKind.String);
                        }
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }
        public static bool GetCredential(ref string UserName, ref string Password)
        {
            string Key = @"SOFTWARE\BankSystem";
            string svUserName = "UserName";
            string svPassword = "Password";
            try
            {
                using(RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(Key, true))
                {
                    if (RegKey != null)
                    {
                        UserName = (string)RegKey.GetValue(svUserName, null);
                        Password = (string)RegKey.GetValue(svPassword, null);
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }
    }
}
