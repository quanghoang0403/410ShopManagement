using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { instance = value; }
        }

        private AccountDAL() { }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Account_AllDetail");
        }
        public bool Login(string username, string passwordd)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("USP_LOGIN @username , @passwordd ", new object[] { username, passwordd });
            return result.Rows.Count > 0;
        }

        public bool InsertAccount(string username, string passwordd, string permision, int id_Staff)
        {
            int id_Account = 0;
            string statement = "Insert";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Account_AllDetail @username , @passwordd , @permision , @id_Staff , @statement , @id_Account ", new object[] { username, passwordd, permision, id_Staff, statement, id_Account });
            return result > 0;
        }

        public bool UpdateAccount(string username, string passwordd, string permision, int id_Staff, int id_Account)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Account_AllDetail @username , @passwordd , @permision , @id_Staff , @statement , @id_Account ", new object[] { username, passwordd, permision, id_Staff, statement, id_Account });
            return result > 0;
        }
    }
}
