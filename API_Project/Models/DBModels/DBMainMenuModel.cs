using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class DBMainMenuModel
    {
        public long? Id_Main { get; set; }
        public long Id_Module { get; set; }
        public int Position { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string GroupName { get; set; }
        public string Target { get; set; }
        public string AllowPermit { get; set; }
        public string AllowCode { get; set; }
        public bool IsDisabled { get; set; }
    }
}
