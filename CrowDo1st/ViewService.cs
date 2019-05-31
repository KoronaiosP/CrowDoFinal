using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrowDo1st
{
    public class ViewService : IViewService
    {
        public Result<List<string>> ViewPendingProjects()
        {
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>();
            var pendingProjects = new List<string>();
            foreach (var p in projects)
            {
                if (p.Active == true)
                {
                    pendingProjects.Add(p.Title);
                    //Console.WriteLine(p.ToString());
                }
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = pendingProjects };
        }


        public Result<List<string>> ViewcompletedProjects()
        {
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>();
            var completedProjects = new List<string>();
            foreach (var p in projects)
            {
                if (p.Active == false)
                {
                    completedProjects.Add(p.Title);
                    //Console.WriteLine(p.ToString());
                }
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = completedProjects };
        }

        public Result<List<string>> ViewProjects()
        {
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>().ToList();
            var allProjects = new List<string>();
            foreach (var p in projects)
            {

                allProjects.Add(p.Title);
                //Console.WriteLine($"{p.Title}");
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = allProjects };
        }

        public Result<List<ProjectProfilePage>> FundedProjects(string email)
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
                }
            }
            return new Result<List<ProjectProfilePage>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = fundedProjects };

        }

        //public Result<List<string>> ViewByCategory(string category)
        //{
        //    var context = new CrowDoDbContext();
        //    var items = context.Set<ProjectProfilePage>().Where(c => c.Category == category);
        //    var projectsByCategory = new List<string>();
        //    foreach (var p in items)
        //    {
        //        projectsByCategory.Add(p.Title);
        //    }
        //    return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = projectsByCategory };
        //}
        public Result<List<string>> ViewByCategory(string category)
        {

            var context = new CrowDoDbContext();
            var projectsByCategory = new List<string>();
            var punctuation = category.Where(char.IsPunctuation).Distinct().ToArray();
            var wordsOfCategory = category.Split().Select(x => x.Trim(punctuation));
            var projects = context.Set<ProjectProfilePage>();
            foreach (var wrd in wordsOfCategory)
            {
                foreach (var p in projects)
                {
                    if (p.Category == null) continue;
                    string categry = p.Category;
                    var punctuation1 = categry.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = categry.Split().Select(x => x.Trim(punctuation1));
                    foreach (var c in words)
                    {
                        if (c == wrd)
                        {
                            projectsByCategory.Add(p.Title);
                        }
                    }
                }
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = projectsByCategory };
        }


        //public Result<List<string>> ViewByText(string text)
        //{
        //    var context = new CrowDoDbContext();
        //    var punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();
        //    var words = text.Split().Select(x => x.Trim(punctuation));
        //    var projects = context.Set<ProjectProfilePage>();
        //    var foundprojects = new List<ProjectProfilePage>();
        //    foreach (var word in words)
        //    { 
        //        foreach (var p in projects)
        //        {
        //            var array = p.Title.Split(' ');
        //            foreach (var a in array)
        //            {
        //                if (word == a)
        //                {
        //                    foundprojects.Add(p);
        //                }
        //            }
        //        }
        //    }
        //    var results = new List<string>();
        //    foreach (var r in foundprojects)
        //    {
        //        results.Add(r.Title);
        //        Console.WriteLine($"Title: {r.Title}");
        //    }

        //    return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = results };
        //}

        public Result<List<string>> ViewByText(string text)
        {
            var context = new CrowDoDbContext();
            var punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();
            var words = text.Split().Select(x => x.Trim(punctuation));
            var projects = context.Set<ProjectProfilePage>();
            // var foundprojects = new List<ProjectProfilePage>();
            var results = new List<string>();
            foreach (var word in words)
            {
                foreach (var p in projects)
                {
                    var array = p.Title.Split(' ');
                    foreach (var a in array)
                    {
                        if (word == a)
                        {
                            results.Add(p.Title);
                        }
                    }
                }
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = results };
        }


        public Result<List<string>> ViewByCreator(string name)
        {
            var context = new CrowDoDbContext();
            var projectList = context.Set<ProjectProfilePage>()
               .Where(p => p.Creator.Name == name).ToList();

            var results = new List<string>();
            foreach (var project in projectList)
            {
                results.Add(project.Title);
                //Console.WriteLine($"Title: {project.Title}");
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = results };


        }


        public Result<List<string>> ViewByYear(int year)
        {
            string yr = year.ToString();
            var context = new CrowDoDbContext();
            var projects = context.Set<ProjectProfilePage>();
            var listOfProjects = new List<string>();
            foreach (var p in projects)
            {
                var array = p.DateOfCreation.ToString("yyyy-mm-dd").Split(new char[] { ' ', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var a in array)
                {
                    if (a == yr)
                    {
                        listOfProjects.Add(p.Title);
                    }
                }
            }
            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = listOfProjects };
        }



        public Result<List<string>> ViewDetailsOfProject(string title)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().Where(p => p.Title == title).Include(p => p.Creator).SingleOrDefault();
            var details = new List<string>
            {
                project.Title,
                project.Description,
                project.DateOfCreation.ToString(("yyyy-mm-dd")),
                project.DeadLine.ToString(("yyyy-mm-dd")),
                $"{project.Goal}",
                project.Category

            };
            project.ViewsCounter++;
            //project.Creator.ViewsCounter++;


            return new Result<List<string>> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = details };
        }


    }
}
