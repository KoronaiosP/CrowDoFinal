using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public class UserProject 
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int ProjectProfilePageId { get; set; }

        [JsonIgnore]
        public ProjectProfilePage Project { get; set; }
        
        public UserProject()
        {

        }
    }

}
