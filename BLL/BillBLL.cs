using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillBLL
    {
        private static BillBLL instance;
        public static BillBLL Instance
        {
            get { if (instance == null) instance = new BillBLL(); return instance; }
            private set { instance = value; }
        }
        private BillBLL() { }
        public List<BillDetailDTO> LoadBillList()
        {
            List<BillDetailDTO> BillList = new List<BillDetailDTO>();
            DataTable data = BillDAL.Instance.GetListBill();
            foreach (DataRow item in data.Rows)
            {
                BillDetailDTO ib = new BillDetailDTO(item);
                BillList.Add(ib);
            }
            return BillList;
        }
        public bool UpdateBill(int id_Staff, DateTime date, int total_Bill, int id_Bill)
        {
            return BillDAL.Instance.UpdateBill(id_Staff, date, total_Bill, id_Bill);
        }

        public bool InsertBill(int id_Staff, DateTime date, int total_Bill)
        {
            return BillDAL.Instance.InsertBill(id_Staff, date, total_Bill);
        }
    }
}
