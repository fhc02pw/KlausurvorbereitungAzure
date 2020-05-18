using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string author { get; set; }
        public string comment { get; set; }
    }
}
