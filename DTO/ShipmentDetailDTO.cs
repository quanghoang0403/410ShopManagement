using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShipmentDetailDTO
    {
        public ShipmentDetailDTO(int id_ShipmentDetail, int id_Shipment, int id_Product, int quantity_Product)
        {
            this.Id_ShipmentDetail = id_ShipmentDetail;
            this.Id_Shipment = id_Shipment;
            this.Id_Product = id_Product;
            this.Quantity_Product = quantity_Product;
        }

        public ShipmentDetailDTO(DataRow row)
        {
            this.Id_ShipmentDetail = (int)Convert.ToInt32(row["Id_ShipmentDetail"].ToString());
            this.Id_Shipment = (int)Convert.ToInt32(row["Id_Shipment"].ToString());
            this.Id_Product = (int)Convert.ToInt32(row["Id_Product"].ToString());
            this.Quantity_Product = (int)Convert.ToInt32(row["Quantity_Product"].ToString());
        }

        private int id_ShipmentDetail;
        private int id_Shipment;
        private int id_Product;
        private int quantity_Product;

        public int Id_ShipmentDetail
        {
            get { return id_ShipmentDetail; }
            set { id_ShipmentDetail = value; }
        }

        public int Id_Shipment
        {
            get { return id_Shipment; }
            set { id_Shipment = value; }
        }
        public int Id_Product
        {
            get { return id_Product; }
            set { id_Product = value; }
        }
        public int Quantity_Product
        {
            get { return quantity_Product; }
            set { quantity_Product = value; }
        }
    }
}
