using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class DBTransaction
    {
        public long? IdTransaction { get; set; }
        public long IdAccount { get; set; }
    }

    public class DBTransactionDetail
    {
        public long? IdTransactionDetail { get; set; }
        public long IdTransaction { get; set; }
        public long IdItem { get; set; }
        public int Quantity { get; set; }
        public decimal Money { get; set; }
    }

}
