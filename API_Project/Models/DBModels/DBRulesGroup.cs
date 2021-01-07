using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class DBRulesGroup
    {
        public string CodeGroup { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string Id_Parent { get; set; }
    }
}
