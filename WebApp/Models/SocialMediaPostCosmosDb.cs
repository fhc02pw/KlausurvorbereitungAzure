using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SocialMediaPostCosmosDb
    {
        public string idDb { get; set; }
        public string postDb { get; set; }
        public string topicDb { get; set; }
        public IList<Comment> commentsDb { get; set; }
    }
}
