using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public partial class DBUser
    {
        public long? IdUser { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public bool IsDelete { get; set; }
    }
}
