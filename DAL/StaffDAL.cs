using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDAL
    {
        private static StaffDAL instance;

        public static StaffDAL Instance
        {
            get { if (instance == null) instance = new StaffDAL(); return StaffDAL.instance; }
            private set { StaffDAL.instance = value; }
        }

        private StaffDAL() { }

        public DataTable GetListStaff()
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Staff_AllDetail");
        }

        public bool InsertStaff(string name_Staff, string position)
        {
            string statement = "Insert";
            int id_Staff = 0;
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Staff_AllDetail @name_Staff , @position , @statement , @id_Staff  ", new object[] { name_Staff, position, statement, id_Staff });
            return result > 0;
        }

        public bool UpdateStaff(string name_Staff, string position, int id_Staff)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Staff_AllDetail @name_Staff , @position , @statement , @id_Staff ", new object[] { name_Staff, position, statement, id_Staff });
            return result > 0;
        }
    }
}
