using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class ProjectProfilePage
    {
        
        public int ProjectProfilePageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime DateOfCreation { get; set; }
        public DateTime DeadLine { get; set; }
        //public int DurationInMonths { get; set; }
        public decimal Balance { get; set; }
         public decimal Goal { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        //public decimal Demandedfunds { get; set; }
        public List<Photos> Photos { get; set; }
        public List<Videos> Videos { get; set; }
        public List<Updates> Update { get; set; }
        public List<UserProject> UserProject { get; set; }
        public List<Package> Packages { get; set; }
        public User Creator { get; set; }
        public int ViewsCounter { get; set; }
        

        public ProjectProfilePage()
        {
            Update = new List<Updates>();
            UserProject = new List<UserProject>();
            Photos = new List<Photos>();
            Videos = new List<Videos>();
            Packages = new List<Package>();
            ViewsCounter = 0;
        }

        public override string ToString()
        {
            return $"{Title},{DeadLine.ToString("yyyy/M/dd ")},{Goal},{Balance}";
        }
    }
}
