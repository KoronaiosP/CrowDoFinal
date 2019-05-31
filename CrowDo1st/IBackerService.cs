using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IBackerService
    {
        Result<bool> FundProject(string email, string projectName, decimal amount);
        

    }
}
