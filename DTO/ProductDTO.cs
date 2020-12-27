using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public ProductDTO(int id_Product, string name_Product, string images, int import_Price, int export_Price, string material, string origin, string product_Category, string size, string color, string descriptions, string sex, int offset, int sold_Quantity, int storage_Quantity, int failure_Quantity)
        {
            this.Id_Product = id_Product;
            this.Name_Product = name_Product;
            this.Images = images;
            this.Import_Price = import_Price;
            this.Export_Price = export_Price;
            this.Material = material;
            this.Origin = origin;
            this.Product_Category = product_Category;
            this.Size = size;
            this.Color = color;
            this.Descriptions = descriptions;
            this.Sex = sex;
            this.Offset = offset;
            this.Sold_Quantity = sold_Quantity;
            this.Storage_Quantity = storage_Quantity;
            this.Failure_Quantity = failure_Quantity;
        }

        public ProductDTO(DataRow row)
        {
            this.Id_Product = (int)Convert.ToInt32(row["Id_Product"].ToString());
            this.Name_Product = row["Name_Product"].ToString();
            this.Images = row["Images"].ToString();
            this.Import_Price = (int)Convert.ToInt32(row["Import_Price"].ToString());
            this.Export_Price = (int)Convert.ToInt32(row["Export_Price"].ToString());
            this.Material = row["Material"].ToString();
            this.Origin = row["Origin"].ToString();
            this.Product_Category = row["Product_Category"].ToString();
            this.Size = row["Size"].ToString();
            this.Color = row["Color"].ToString();
            this.Descriptions = row["Descriptions"].ToString();
            this.Sex = row["Sex"].ToString();
            this.Offset = (int)Convert.ToInt32(row["Offset"].ToString());
            this.Sold_Quantity = (int)Convert.ToInt32(row["Sold_Quantity"].ToString());
            this.Storage_Quantity = (int)Convert.ToInt32(row["Storage_Quantity"].ToString());
            this.Failure_Quantity = (int)Convert.ToInt32(row["Failure_Quantity"].ToString());
        }

        private int id_Product;
        private string name_Product;
        private string images;
        private int import_Price;
        private int export_Price;
        private string material;
        private string origin;
        private string product_Category;
        private string size;
        private string color;
        private string descriptions;
        private string sex;
        private int offset;
        private int sold_Quantity;
        private int storage_Quantity;
        private int failure_Quantity;

        public int Id_Product
        {
            get { return id_Product; }
            set { id_Product = value; }
        }
        public string Name_Product
        {
            get { return name_Product; }
            set { name_Product = value; }
        }
        public string Images
        {
            get { return images; }
            set { images = value; }
        }
        public int Import_Price
        {
            get { return import_Price; }
            set { import_Price = value; }
        }
        public int Export_Price
        {
            get { return export_Price; }
            set { export_Price = value; }
        }
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public string Product_Category
        {
            get { return product_Category; }
            set { product_Category = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        public int Sold_Quantity
        {
            get { return sold_Quantity; }
            set { sold_Quantity = value; }
        }
        public int Storage_Quantity
        {
            get { return storage_Quantity; }
            set { storage_Quantity = value; }
        }
        public int Failure_Quantity
        {
            get { return failure_Quantity; }
            set { failure_Quantity = value; }
        }
    }
}
