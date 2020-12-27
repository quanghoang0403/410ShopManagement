using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillDAL
    {
        private static BillDAL instance;

        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return BillDAL.instance; }
            private set { BillDAL.instance = value; }
        }

        private BillDAL() { }

        public DataTable GetListBill()
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Bill_AllDetail");
        }

        public bool InsertBill(int id_Staff, DateTime date, int total_Bill)
        {
            int id_Bill = 0;
            string statement = "Insert";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_AllDetail @id_Staff , @date , @total_Bill , @statement , @id_Bill ", new object[] { id_Staff, date, total_Bill, statement, id_Bill });
            return result > 0;
        }

        public bool UpdateBill(int id_Staff, DateTime date, int total_Bill, int id_Bill)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_AllDetail @id_Staff , @date , @total_Bill , @statement , @id_Bill ", new object[] { id_Staff, date, total_Bill, statement, id_Bill });
            return result > 0;
        }
    }
}

