using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class ProjectCategory
    {
        [Key]
        public int ProjectProfilePageId { get; set; }
        public int CategoryId { get; set; }
        public ProjectProfilePage Project { get; set; }
        public Category Category { get; set; }

        public ProjectCategory()
        {
        }
    }
}
