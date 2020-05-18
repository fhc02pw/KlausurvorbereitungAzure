using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SocialMediaPost
    {
        public int id { get; set; }
        public string post{ get; set; }
        public string topic { get; set; }
        public IList<Comment> comments { get; set; }
    }
}
