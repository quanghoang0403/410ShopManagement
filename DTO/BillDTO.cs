using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        public BillDTO(int id_Bill, int id_Staff, string export_Date, int total_Bill)
        {
            this.Id_Bill = id_Bill;
            this.Id_Staff = id_Staff;
            this.Export_Date = export_Date;
            this.Total_Bill = total_Bill;
        }

        public BillDTO(DataRow row)
        {
            this.Id_Bill = (int)Convert.ToInt32(row["Id_Bill"].ToString());
            this.Id_Staff = (int)Convert.ToInt32(row["Id_Staff"].ToString());
            this.Export_Date = Convert.ToDateTime(row["Export_Date"]).ToString("d");
            this.Total_Bill = (int)Convert.ToInt32(row["Total_Bill"].ToString());
        }

        private int id_Bill;
        private int id_Staff;
        private string export_Date;
        private int total_Bill;


        public int Id_Bill
        {
            get { return id_Bill; }
            set { id_Bill = value; }
        }

        public int Id_Staff
        {
            get { return id_Staff; }
            set { id_Staff = value; }
        }
        public string Export_Date
        {
            get { return export_Date; }
            set { export_Date = value; }
        }
        public int Total_Bill
        {
            get { return total_Bill; }
            set { total_Bill = value; }
        }
    }
}
