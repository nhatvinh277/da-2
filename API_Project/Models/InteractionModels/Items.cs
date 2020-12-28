using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class ItemsModel
    {
        public long? IdItem { get; set; }
        public long IdType { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public decimal Sales { get; set; }
        public decimal RateAvg { get; set; }
        public decimal RateNumber { get; set; }
        public string LinkImage { get; set; }
        public List<UserReview> UserReview { get; set; } = new List<UserReview>();
    }

    public class UserReview
    {
        public string AccountName { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public decimal Rate { get; set; }

    }


    public class ItemsOrdersModel
    {
        public long IdItem { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public int Quantity { get; set; }
    }
}
