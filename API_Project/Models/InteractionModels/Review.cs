﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Models
{
    public class Review
    {
        public long? Id { get; set; }
        public long IdAccount { get; set; }
        public long IdTransactionDetail { get; set; }
        public long IdItem { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
    }
}
