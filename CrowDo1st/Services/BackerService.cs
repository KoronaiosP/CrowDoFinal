using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrowDo1st
{
    public class BackerService : IBackerService
    {
        public Result<bool> FundProject(string email, string projectName, decimal amount) //string titleOfPackage)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if (project==null)
            {
                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Project Not Found", Data = true };
            }
            var user = context.Set<User>().SingleOrDefault(u => u.Email == email);
            if (user==null)
            {
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Email doesnt exist", Data = true };
            }
            if (!user.Activity)
            {
                user.Activity = true;
            }
            var fp = new UserProject();
            user.UserProject.Add(fp);
            project.UserProject.Add(fp);
            project.Balance += amount;
            if (project.Balance >= project.Goal)
            {
                project.Active = false;
                context.SaveChanges();
            }
            context.SaveChanges();
            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Project Funded", Data = true };
        }

        public List<ProjectProfilePage> BackersFundedProjects(string email)
        {
            var context = new CrowDoDbContext();
            var fundedProjects = new List<ProjectProfilePage>();
            var user = context.Set<User>().SingleOrDefault(e => e.Email == email);
            int id = user.UserId;
            var proj = context.Set<UserProject>().Where(u => u.UserId == id);
            foreach (var f in proj)
            {
                var fp = context.Set<ProjectProfilePage>().Where(pid => pid.ProjectProfilePageId == f.ProjectProfilePageId);
                foreach (var item in fp)
                {
                    fundedProjects.Add(item);
                    Console.WriteLine($"{item.Title},{item.Balance}");
                }
            }
            return fundedProjects;

        }



    }
}
