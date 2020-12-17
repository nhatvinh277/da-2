using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class DBTypeItems
    {
        public long? IdType { get; set; }
        public string Name { get; set; }
        public long IdMainMenu { get; set; }
    }
}
