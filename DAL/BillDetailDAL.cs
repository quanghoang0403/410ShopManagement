using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillDetailDAL
    {
        private static BillDetailDAL instance;

        public static BillDetailDAL Instance
        {
            get { if (instance == null) instance = new BillDetailDAL(); return BillDetailDAL.instance; }
            private set { BillDetailDAL.instance = value; }
        }

        private BillDetailDAL() { }

        public DataTable GetListBillDetail(int id_Bill)
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Bill_Detail_AllDetail @id_Bill", new object[] { id_Bill });
        }

        public bool InsertBillDetail(int id_Bill, int id_Product, int quantity_Product)
        {
            string statement = "Insert";
            int id_BillDetail = 0;
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_Detail_AllDetail @id_Bill , @id_Product , @quantity_Product , @statement , @id_BillDetail ", new object[] { id_Bill, id_Product, quantity_Product, statement, id_BillDetail });
            return result > 0;
        }

        public bool UpdateBillDetail(int id_Bill, int id_Product, int quantity_Product, int id_BillDetail)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_Detail_AllDetail @id_Bill , @id_Product , @quantity_Product , @statement , @id_BillDetail ", new object[] { id_Bill, id_Product, quantity_Product, statement, id_BillDetail });
            return result > 0;
        }
    }
}
