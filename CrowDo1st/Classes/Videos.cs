using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class Videos
    {
        [Key]
        public int VideoId { get; set; }
        public string Name { get; set; }
       
        public Videos()
        {
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
