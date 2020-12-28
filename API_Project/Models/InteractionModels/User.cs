using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public partial class UserModel
    {
        public long? IdUser { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public bool IsDelete { get; set; }
    }

    public class UserModelLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class UserModelCreate
    {
        public long? IdAccount { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string repassword { get; set; }

        public string fullname { get; set; }
        public int gender { get; set; }
        public DateTime birthdate { get; set; }
        public string address { get; set; }
        public string nationality { get; set; }
    }
}
