using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class Transaction
    {
        public long? IdTransaction { get; set; }
        public long IdAccount { get; set; }
        public List<ItemTransaction> items { get; set; }
    }

    public class TransactionDetail
    {
        public long? IdTransactionDetail { get; set; }
        public long? IdTransaction { get; set; }
        public long IdItem { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public int Quantity { get; set; }
        public int TongTien { get; set; }
        public DateTime Created { get; set; }
        public string TrangThai { get; set; }
        public string TransactionCode { get; set; }
    }

    public class ItemTransaction
    {
        public long IdItem { get; set; }
        public int Quantity { get; set; }
        public decimal Money { get; set; }
    }
}
