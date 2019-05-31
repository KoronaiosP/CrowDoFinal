using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IViewService
    {
        Result<List<string>> ViewPendingProjects();



        Result<List<string>> ViewProjects();



        Result<List<ProjectProfilePage>> FundedProjects(string email);



        Result<List<string>> ViewByCategory(string category);



        Result<List<string>> ViewByText(string text);


        Result<List<string>> ViewByCreator(string name);


        Result<List<string>> ViewByYear(int year);


        Result<List<string>> ViewDetailsOfProject(string title);
    }
}
