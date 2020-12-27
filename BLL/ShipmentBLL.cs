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
    public class ShipmentBLL
    {
        private static ShipmentBLL instance;

        public static ShipmentBLL Instance
        {
            get { if (instance == null) instance = new ShipmentBLL(); return ShipmentBLL.instance; }
            private set { ShipmentBLL.instance = value; }
        }

        private ShipmentBLL() { }

        public List<ShipmentDTO> GetListShipment()
        {
            List<ShipmentDTO> listBillInfo = new List<ShipmentDTO>();

            DataTable data = ShipmentDAL.Instance.GetListShipment();

            foreach (DataRow item in data.Rows)
            {
                ShipmentDTO info = new ShipmentDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public bool UpdateShipment(DateTime date, int id_Staff, int id_Shipment)
        {
            return ShipmentDAL.Instance.UpdateShipment(date, id_Staff, id_Shipment);
        }

        public bool InsertShipment(DateTime date, int id_Staff)
        {
            return ShipmentDAL.Instance.InsertShipment(date, id_Staff);
        }
    }
}
