using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;

        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set { instance = value; }
        }

        private AccountBLL() { }

        public bool Login(string userName, string passWord)
        {
            return AccountDAL.Instance.Login(userName, passWord);
        }
        //public String GetMD5(string txt)
        //{
        //    String str = "";
        //    Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
        //    System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //    buffer = md5.ComputeHash(buffer);
        //    foreach (Byte b in buffer)
        //    {
        //        str += b.ToString("X2");
        //    }
        //    return str;
        //}
    }
}
