using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShipmentDTO
    {
        public ShipmentDTO(int id_Shipment, string import_date, int id_Staff)
        {
            this.Id_Shipment = id_Shipment;
            this.Import_date = import_date;
            this.Id_Staff = id_Staff;
        }

        public ShipmentDTO(DataRow row)
        {
            this.Id_Shipment = (int)Convert.ToInt32(row["Id_Shipment"].ToString());
            this.Import_date = Convert.ToDateTime(row["Import_date"]).ToString("d");
            this.Id_Staff = (int)Convert.ToInt32(row["Id_Staff"].ToString());
        }

        private int id_Shipment;
        private string import_date;
        private int id_Staff;


        public int Id_Shipment
        {
            get { return id_Shipment; }
            set { id_Shipment = value; }
        }

        public string Import_date
        {
            get { return import_date; }
            set { import_date = value; }
        }
        public int Id_Staff
        {
            get { return id_Staff; }
            set { id_Staff = value; }
        }
    }
}
