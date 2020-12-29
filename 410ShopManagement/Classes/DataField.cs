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
        public List<Staff> staffs;
        public List<Account> accounts;
        public List<Bill> bills;
        public List<BillDetail> billDetails;

        public int idCurrentAccountLogin;

        private DataField() 
        {
            #region Product
            products = new List<Product>();
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "White Fernweh Jacket",
                imagePath = appImageHeader + "Jacket_White_Fernweh.png",
                importPrice = 500000,
                saleOffset = 20,
                material = "Bio",
                origin = "Fernweh",
                category = "Jacket",
                sex = "Unisex",
                size = "M",
                color = "White",
                description = "ON SALE",
                storageQuantity = 24,
                soldQuantity = 76,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Black Fernweh Jacket",
                imagePath = appImageHeader + "Jacket_Black_Fernweh.png",
                importPrice = 500000,
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
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Pink Fernweh Cardigan",
                imagePath = appImageHeader + "Cardigan_Pink_Fernweh.png",
                importPrice = 400000,
                saleOffset = 50,
                material = "Synthetic fibers",
                origin = "Fernweh",
                category = "Cardigan",
                sex = "Unisex",
                size = "L",
                color = "Pink",
                description = "ON SALE",
                storageQuantity = 73,
                soldQuantity = 27,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Purple Fernweh Hoodie",
                imagePath = appImageHeader + "Hoodie_Purple_Fernweh.png",
                importPrice = 350000,
                saleOffset = 15,
                material = "Cotton",
                origin = "Fernweh",
                category = "Hoodie",
                sex = "Female",
                size = "M",
                color = "Purple",
                description = "ON SALE",
                storageQuantity = 83,
                soldQuantity = 17,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "GameOver Tokago TShirt",
                imagePath = appImageHeader + "Shirt_GameOver_Tokago.png",
                importPrice = 220000,
                saleOffset = 0,
                material = "Cotton",
                origin = "Tokago",
                category = "Tshirt",
                sex = "Unisex",
                size = "L",
                color = "Jade",
                description = "Trending",
                storageQuantity = 13,
                soldQuantity = 87,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Pink Tokago Shirt",
                imagePath = appImageHeader + "Shirt_Pink_Tokago.png",
                importPrice = 200000,
                saleOffset = 10,
                material = "Cotton",
                origin = "Tokago",
                category = "Shirt",
                sex = "Unisex",
                size = "M",
                color = "Pink",
                description = "ON SALE",
                storageQuantity = 80,
                soldQuantity = 20,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Satan Tokago Shirt",
                imagePath = appImageHeader + "Shirt_Satan_Tokago.png",
                importPrice = 220000,
                saleOffset = 0,
                material = "Cotton",
                origin = "Tokago",
                category = "Shirt",
                sex = "Unisex",
                size = "L",
                color = "White",
                description = "Sold out",
                storageQuantity = 0,
                soldQuantity = 100,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Yellow Fernweh Sweetshirt",
                imagePath = appImageHeader + "Sweetshirt_Yellow_Fernweh.png",
                importPrice = 450000,
                saleOffset = 20,
                material = "Polyester",
                origin = "Fernweh",
                category = "Sweetshirt",
                sex = "Unisex",
                size = "L",
                color = "Yellow",
                description = "ON SALE",
                storageQuantity = 65,
                soldQuantity = 35,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Mint Teelab TShirt",
                imagePath = appImageHeader + "Tshirt_Mint_Teelab.png",
                importPrice = 250000,
                saleOffset = 0,
                material = "Cotton",
                origin = "Teelab",
                category = "Tshirt",
                sex = "Unisex",
                size = "M",
                color = "Mint",
                description = "Trending",
                storageQuantity = 75,
                soldQuantity = 25,
                cancelQuantity = 0
            });
            products.Add(new Product()
            {
                idProduct = products.Count,
                nameProduct = "Perry Tokago TShirt",
                imagePath = appImageHeader + "Tshirt_Mint_Tokago.png",
                importPrice = 220000,
                saleOffset = 0,
                material = "Cotton",
                origin = "Tokago",
                category = "Tshirt",
                sex = "Unisex",
                size = "L",
                color = "Mint",
                description = "ON FIREEEEE !!",
                storageQuantity = 4,
                soldQuantity = 96,
                cancelQuantity = 0
            });
            foreach (Product item in products)
            {
                item.exportPrice = item.importPrice - item.importPrice * item.saleOffset / 100;
            }
            #endregion

            #region Account and Staff
            staffs = new List<Staff>();
            accounts = new List<Account>();
            //create account first, then create staff
            //cause: idAccount before Add() = 0, and idStaff at that time = 0
            accounts.Add(new Account()
            {
                idAccount = accounts.Count, //=0 before add done
                userName = "admin",
                password = "n",
                permission = "Manager",
                idStaff = staffs.Count //=0 because create account before staff
            });
            staffs.Add(new Staff()
            {
                idStaff = staffs.Count,
                nameStaff = "DuyDeo",
                position = "Manager"
            });

            accounts.Add(new Account()
            {
                idAccount = accounts.Count,
                userName = "a",
                password = "a",
                permission = "Saler",
                idStaff = staffs.Count
            });
            staffs.Add(new Staff()
            {
                idStaff = staffs.Count,
                nameStaff = "Spider-Man on a part-time job",
                position = "Saler"
            });
            #endregion

            bills = new List<Bill>();
            billDetails = new List<BillDetail>();
            bills.Add(new Bill()
            {
                idBill = bills.Count,
                idStaff = 0,
                exportDate = "12/1/2020"
            });
            bills.Add(new Bill()
            {
                idBill = bills.Count,
                idStaff = 1,
                exportDate = "12/2/2020"
            });
            bills.Add(new Bill()
            {
                idBill = bills.Count,
                idStaff = 1,
                exportDate = "12/2/2020"
            });
            billDetails.Add(new BillDetail()
            {
                idBillDetail = billDetails.Count,
                idBill = 0,
                idProduct = 0,
                quantityProduct = 10
            });
            billDetails.Add(new BillDetail()
            {
                idBillDetail = billDetails.Count,
                idBill = 0,
                idProduct = 1,
                quantityProduct = 5
            });
            billDetails.Add(new BillDetail()
            {
                idBillDetail = billDetails.Count,
                idBill = 1,
                idProduct = 2,
                quantityProduct = 5
            });
            billDetails.Add(new BillDetail()
            {
                idBillDetail = billDetails.Count,
                idBill = 1,
                idProduct = 3,
                quantityProduct = 4
            });
            billDetails.Add(new BillDetail()
            {
                idBillDetail = billDetails.Count,
                idBill = 2,
                idProduct = 4,
                quantityProduct = 4
            });
            foreach (BillDetail item in billDetails)
            {
                foreach (Product prod in products)
                {
                    if (item.idProduct == prod.idProduct)
                    {
                        item.priceProduct = prod.exportPrice;
                    }
                }
                item.totalPrice = item.priceProduct * item.quantityProduct;
                foreach (Bill bill in bills)
                {
                    if (bill.idBill == item.idBill)
                    {
                        bill.totalBill += item.totalPrice;
                    }
                }
            }
        }
    }
}
