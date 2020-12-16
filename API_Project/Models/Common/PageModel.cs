using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Project.Models
{
    public class PageModel
    {
        public int Page { get; set; } = 1;
        public int AllPage { get; set; } = 0;
        public int Size { get; set; } = 10;
        public int TotalCount { get; set; } = 0;
    }
}