using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShipmentDAL
    {
        private static ShipmentDAL instance;

        public static ShipmentDAL Instance
        {
            get { if (instance == null) instance = new ShipmentDAL(); return ShipmentDAL.instance; }
            private set { ShipmentDAL.instance = value; }
        }

        private ShipmentDAL() { }

        public DataTable GetListShipment()
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Shipment_AllDetail");
        }

        public bool InsertShipment(DateTime date, int id_Staff)
        {
            string statement = "Insert";
            int id_Shipment = 0;
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Shipment_AllDetail @date , @id_Staff , @statement , @id_Shipment ", new object[] { date, id_Staff, statement, id_Shipment });
            return result > 0;
        }

        public bool UpdateShipment(DateTime date, int id_Staff, int id_Shipment)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Shipment_AllDetail @date , @id_Staff , @statement , @id_Shipment ", new object[] { date, id_Staff, statement, id_Shipment });
            return result > 0;
        }
    }
}
