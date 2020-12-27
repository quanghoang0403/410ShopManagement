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
    public class ProductBLL
    {
        private static ProductBLL instance;

        public static ProductBLL Instance
        {
            get { if (instance == null) instance = new ProductBLL(); return ProductBLL.instance; }
            private set { ProductBLL.instance = value; }
        }

        private ProductBLL() { }

        public List<ProductDTO> GetListProduct()
        {
            List<ProductDTO> listBillInfo = new List<ProductDTO>();

            DataTable data = ProductDAL.Instance.GetListProduct();

            foreach (DataRow item in data.Rows)
            {
                ProductDTO info = new ProductDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public bool UpdateBillDetail(string name_Product, string images, int import_Price, int export_Price, string material, string origin, string product_Category, string size, string color, string descriptions, string sex, int offset, int sold_Quantity, int storage_Quantity, int failure_Quantity, int id_BillDetail)
        {
            return ProductDAL.Instance.UpdateProduct(name_Product, images, import_Price, export_Price, material, origin, product_Category, size, color, descriptions, sex, offset, sold_Quantity, storage_Quantity, failure_Quantity, id_BillDetail);
        }

        public bool InsertProduct(string name_Product, string images, int import_Price, int export_Price, string material, string origin, string product_Category, string size, string color, string descriptions, string sex, int offset, int sold_Quantity, int storage_Quantity, int failure_Quantity)
        {
            return ProductDAL.Instance.InsertProduct(name_Product, images, import_Price, export_Price, material, origin, product_Category, size, color, descriptions, sex, offset, sold_Quantity, storage_Quantity, failure_Quantity);
        }
    }
}
