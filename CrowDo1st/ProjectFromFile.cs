using System;
using System.Collections.Generic;
using System.Text;

namespace  CrowDo1st

{
    public class ProjectFromFile
    {
        public string NameOfProject { get; set; }
        public string Description { get; set; }

        public string Creator { get; set; }
        public string Keywords { get; set; }
        public decimal Demandedfunds { get; set; }
        public string DateOfCreation { get; set; }
        public string Deadline { get; set; }
        public int DurationInMonths { get; set; }
    }
}