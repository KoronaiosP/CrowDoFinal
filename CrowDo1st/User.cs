using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrowDo1st
{
    public class User
    {
        
        public int UserId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        
        public DateTime DateOfRegister { get; set; }
        public string Location { get; set; }
        
        public string CardNumber { get; set; }
        public bool Activity { get; set; }
        public List<ProjectProfilePage> CreatedProjects { get; set; }
        public List<UserProject> UserProject { get; set; }
        public int ViewsCounter { get; set; }

        public User()
        {
            CreatedProjects = new List<ProjectProfilePage>();
            UserProject = new List<UserProject>();
            ViewsCounter = 0;
            Activity = true;
        }
    }
}
