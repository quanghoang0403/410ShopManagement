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
    public class ShipmentDetailBLL
    {
        private static ShipmentDetailBLL instance;

        public static ShipmentDetailBLL Instance
        {
            get { if (instance == null) instance = new ShipmentDetailBLL(); return ShipmentDetailBLL.instance; }
            private set { ShipmentDetailBLL.instance = value; }
        }

        private ShipmentDetailBLL() { }

        public List<ShipmentDetailDTO> GetListShipmentDetail(int id_Shipment)
        {
            List<ShipmentDetailDTO> listBillInfo = new List<ShipmentDetailDTO>();

            DataTable data = ShipmentDetailDAL.Instance.GetListShipmentDetail(id_Shipment);

            foreach (DataRow item in data.Rows)
            {
                ShipmentDetailDTO info = new ShipmentDetailDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public bool UpdateShipmentDetail(int id_Shipment, int id_Product, int quantity_Product, int id_ShipmentDetail)
        {
            return ShipmentDetailDAL.Instance.UpdateShipmentDetail(id_Shipment, id_Product, quantity_Product, id_ShipmentDetail);
        }

        public bool InsertShipmentDetail(int id_Shipment, int id_Product, int quantity_Product)
        {
            return ShipmentDetailDAL.Instance.InsertShipmentDetail(id_Shipment, id_Product, quantity_Product);
        }
    }
}
