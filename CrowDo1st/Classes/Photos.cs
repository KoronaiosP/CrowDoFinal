using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowDo1st
{
    public class Photos
    {
        [Key]
        public int PhotoId { get; set;}
        public string Name { get; set; }
       
        public Photos()
        {

        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
