using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class Clicker
    {
        public long? Id { get; set; }
        public long IdAccount { get; set; }
        public long IdTransactionDetail { get; set; }
        public long IdItem { get; set; }
        public int Click { get; set; }
        public DateTime Time { get; set; }
    }
}
