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
        public BillDTO(int id_bill, string bill_name, string bill_address, string total_money)
        {
            this.Id_bill = id_bill;
            this.Bill_address = bill_address;
            this.Bill_name = bill_name;
            this.Total_money = total_money;
        }

        public BillDTO(DataRow row)
        {
            this.Id_bill = Convert.ToInt32(row["id_bill"].ToString());
            this.Bill_name = row["bill_name"].ToString();
            this.Bill_address = row["bill_address"].ToString();
            this.Total_money = row["total_money"].ToString();
        }

        private int id_bill;
        private string bill_name;
        private string bill_address;
        private string total_money;

        public int Id_bill
        {
            get { return id_bill; }
            set { id_bill = value; }
        }

        public string Bill_name
        {
            get { return bill_name; }
            set { bill_name = value; }
        }
        public string Bill_address
        {
            get { return bill_address; }
            set { bill_address = value; }
        }

        public string Total_money
        {
            get { return total_money; }
            set { total_money = value; }
        }
    }
}
