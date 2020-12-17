using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class DBItems
    {
        public long? IdItem { get; set; }
        public long IdType { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public decimal Sales { get; set; }
        public decimal RateAvg { get; set; }
        public string LinkImage { get; set; }
    }
}
