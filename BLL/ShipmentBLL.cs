using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShipmentBLL
    {
        private static BillDetailBLL instance;

        public static BillDetailBLL Instance
        {
            get { if (instance == null) instance = new BillDetailBLL(); return BillDetailBLL.instance; }
            private set { BillDetailBLL.instance = value; }
        }

        private BillDetailBLL() { }

        public List<BillDetailDTO> GetListBillDetail(int id_Bill)
        {
            List<BillDetailDTO> listBillInfo = new List<BillDetailDTO>();

            DataTable data = BillDetailDAL.Instance.GetListBillDetail(id_Bill);

            foreach (DataRow item in data.Rows)
            {
                BillDetailDTO info = new BillDetailDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public bool UpdateBillDetail(int id_Bill, int id_Product, int quantity_Product, int id_BillDetail)
        {
            return BillDetailDAL.Instance.UpdateBillDetail(id_Bill, id_Product, quantity_Product, id_BillDetail);
        }

        public bool InsertBillDetail(int id_Bill, int id_Product, int quantity_Product)
        {
            return BillDetailDAL.Instance.InsertBillDetail(id_Bill, id_Product, quantity_Product);
        }
    }
}
