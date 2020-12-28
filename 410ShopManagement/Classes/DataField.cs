using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _410ShopManagement.Classes
{
    public class DataField
    {
        private static DataField instance;

        public static DataField Instance
        {
            get { if (instance == null) instance = new DataField(); return DataField.instance; }
            private set { DataField.instance = value; }
        }

        string appImageHeader = "/410ShopManagement;component/Assets/Products/";
        public List<Product> products;

        private DataField() 
        {
            products = new List<Product>();
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "White Fernweh Jacket",
                imageProduct = appImageHeader + "Jacket_White_Fernweh.png",
                importPriceProduct = 500000,
                saleOffset = 20,
                material = "Bio",
                origin = "Fernweh",
                category = "Jacket",
                sex = "Unisex",
                size = "M",
                color = "White",
                description = "On SALE",
                storageQuantity = 24,
                soldQuantity = 76,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Black Fernweh Jacket",
                imageProduct = appImageHeader + "Jacket_Black_Fernweh.png",
                importPriceProduct = 500000,
                saleOffset = 20,
                material = "Bio",
                origin = "Fernweh",
                category = "Jacket",
                sex = "Unisex",
                size = "L",
                color = "Black",
                description = "Sold out",
                storageQuantity = 0,
                soldQuantity = 100,
                cancelQuantity = 0
            });
            foreach (Product item in products)
            {
                item.exportPriceProduct = item.importPriceProduct - item.importPriceProduct * item.saleOffset / 100;
            }
        }
    }
}
