using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        private static ProductDAL instance;

        public static ProductDAL Instance
        {
            get { if (instance == null) instance = new ProductDAL(); return ProductDAL.instance; }
            private set { ProductDAL.instance = value; }
        }

        private ProductDAL() { }

        public DataTable GetListProduct()
        {
            return DataProvider.Instance.ExecuteQuery("USP_Select_Product_AllDetail");
        }

        public bool InsertProduct(string name_Product, string images, int import_Price, int export_Price, string material, string origin, string product_Category, string size, string color, string descriptions, string sex, int offset, int sold_Quantity, int storage_Quantity, int failure_Quantity)
        {
            string statement = "Insert";
            int id_Product = 0;
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Product_AllDetail @name_Product , @images , @import_Price , @export_Price , @material , @origin , @product_Category , @size , @color , @descriptions , @sex , @offset , @sold_Quantity , @storage_Quantity , @failure_Quantity , @statement , @id_Product ", new object[] { name_Product, images, import_Price, export_Price, material, origin, product_Category, size, color, descriptions, sex, offset, sold_Quantity, storage_Quantity, failure_Quantity, statement, id_Product });
            return result > 0;
        }

        public bool UpdateProduct(string name_Product, string images, int import_Price, int export_Price, string material, string origin, string product_Category, string size, string color, string descriptions, string sex, int offset, int sold_Quantity, int storage_Quantity, int failure_Quantity, int id_Product)
        {
            string statement = "Update";
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Insert_Update_Product_AllDetail @name_Product , @images , @import_Price , @export_Price , @material , @origin , @product_Category , @size , @color , @descriptions , @sex , @offset , @sold_Quantity , @storage_Quantity , @failure_Quantity , @statement , @id_Product ", new object[] { name_Product, images, import_Price, export_Price, material, origin, product_Category, size, color, descriptions, sex, offset, sold_Quantity, storage_Quantity, failure_Quantity, statement, id_Product });
            return result > 0;
        }
    }
}
