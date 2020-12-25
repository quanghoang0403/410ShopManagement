using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        public AccountDTO(string username, string passwordd, string permision, int id_Staff)
        {
            this.Username = username;
            this.Passwordd = passwordd;
            this.Permision = permision;
            this.Id_Staff = id_Staff;
        }

        public AccountDTO(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.Passwordd = row["Passwordd"].ToString();
            this.Permision = row["Permision"].ToString();
            this.Id_Staff = (int)Convert.ToInt32(row["Id_Staff"].ToString());
        }

        private string username;
        private string passwordd;
        private string permision;
        private int id_Staff;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Passwordd
        {
            get { return passwordd; }
            set { passwordd = value; }
        }
        public string Permision
        {
            get { return permision; }
            set { permision = value; }
        }
        public int Id_Staff
        {
            get { return id_Staff; }
            set { id_Staff = value; }
        }
    }
}
