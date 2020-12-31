using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOH
{
    public class StaffDTO
    {
        public StaffDTO(int id_Staff, string name_Staff, string position)
        {
            this.Id_Staff = id_Staff;
            this.Name_Staff = name_Staff;
            this.Position = Position;
        }

        public StaffDTO(DataRow row)
        {
            this.Id_Staff = (int)Convert.ToInt32(row["Id_Staff"].ToString());
            this.Name_Staff = row["Name_Staff"].ToString();
            this.Position = row["Position"].ToString();
        }

        private int id_Staff;
        private string name_Staff;
        private string position;

        public int Id_Staff
        {
            get { return id_Staff; }
            set { id_Staff = value; }
        }
        public string Name_Staff
        {
            get { return name_Staff; }
            set { name_Staff = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
