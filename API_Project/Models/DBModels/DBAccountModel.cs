using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public partial class DBAccount
    {
        public long? IdAccount { get; set; }
        public long? IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CodeGroup { get; set; }
        public string Salt { get; set; }
    }
}
