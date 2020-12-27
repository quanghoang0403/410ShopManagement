using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetailDTO
    {
        public BillDetailDTO(int id_BillDetail, int id_Bill, int id_Product, int price, int quantity_Product, int total_Price)
        {
            this.Id_BillDetail = id_BillDetail;
            this.Id_Bill = id_Bill;
            this.Id_Product = id_Product;
            this.Price = price;
            this.Quantity_Product = quantity_Product;
            this.Total_Price = total_Price;
        }

        public BillDetailDTO(DataRow row)
        {
            this.Id_BillDetail = (int)Convert.ToInt32(row["Id_BillDetail"].ToString());
            this.Id_Bill = (int)Convert.ToInt32(row["Id_Bill"].ToString());
            this.Id_Product = (int)Convert.ToInt32(row["Id_Product"].ToString());
            this.Price = (int)Convert.ToInt32(row["Price"].ToString());
            this.Quantity_Product = (int)Convert.ToInt32(row["Quantity_Product"].ToString());
            this.Total_Price = (int)Convert.ToInt32(row["Total_Price"].ToString());
        }

        private int id_BillDetail;
        private int id_Bill;
        private int id_Product;
        private int price;
        private int quantity_Product;
        private int total_Price;

        public int Id_BillDetail
        {
            get { return id_BillDetail; }
            set { id_BillDetail = value; }
        }

        public int Id_Bill
        {
            get { return id_Bill; }
            set { id_Bill = value; }
        }
        public int Id_Product
        {
            get { return id_Product; }
            set { id_Product = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity_Product
        {
            get { return quantity_Product; }
            set { quantity_Product = value; }
        }
        public int Total_Price
        {
            get { return total_Price; }
            set { total_Price = value; }
        }
    }
}
