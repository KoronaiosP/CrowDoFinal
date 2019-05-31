using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        public decimal LowerBound { get; set; }
        public string Reward { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public ProjectProfilePage Project { get; set; }


    }
}
