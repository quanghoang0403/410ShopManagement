using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShipmentDetailDAL
    {
        private static ShipmentDetailDAL instance;

        public static ShipmentDetailDAL Instance
        {
            get { if (instance == null) instance = new ShipmentDetailDAL(); return ShipmentDetailDAL.instance; }
            private set { ShipmentDetailDAL.instance = value; }
        }

        private ShipmentDetailDAL() { }

        public DataTable GetListShipmentDetail(int id_Shipment)
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Shipment_Detail_AllDetail", new object[] { id_Shipment });
        }

        public bool InsertShipmentDetail(int id_Shipment, int id_Product, int quantity_Product)
        {
            string statement = "Insert";
            int id_ShipmentDetail = 0;
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_AllDetail @id_Staff , @date , @total_Bill , @statement , @id_Bill ", new object[] { id_Shipment, id_Product, quantity_Product, statement, id_ShipmentDetail });
            return result > 0;
        }

        public bool UpdateShipmentDetail(int id_Shipment, int id_Product, int quantity_Product, int id_ShipmentDetail)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Bill_AllDetail @id_Staff , @date , @total_Bill , @statement , @id_Bill ", new object[] { id_Shipment, id_Product, quantity_Product, statement, id_ShipmentDetail });
            return result > 0;
        }


    }
}
