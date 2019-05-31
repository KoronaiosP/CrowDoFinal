using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProjectProfilePage> Projects { get; set; }
        public Category()
        {
            Projects = new List<ProjectProfilePage>();
        }
    }
}
