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
    public class StaffBLL
    {
        private static StaffBLL instance;

        public static StaffBLL Instance
        {
            get { if (instance == null) instance = new StaffBLL(); return StaffBLL.instance; }
            private set { StaffBLL.instance = value; }
        }

        private StaffBLL() { }

        public List<StaffDTO> GetListStaff()
        {
            List<StaffDTO> listBillInfo = new List<StaffDTO>();

            DataTable data = StaffDAL.Instance.GetListStaff();

            foreach (DataRow item in data.Rows)
            {
                StaffDTO info = new StaffDTO(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public bool UpdateStaff(string name_Staff, string position, int id_Staff)
        {
            return StaffDAL.Instance.UpdateStaff(name_Staff, position, id_Staff);
        }

        public bool InsertStaff(string name_Staff, string position)
        {
            return StaffDAL.Instance.InsertStaff(name_Staff, position);
        }
    }
}
