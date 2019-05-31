﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrowDo1st
{
    public class ProjectCreatorService : IProjectCreatorService
    {



        public Result<bool> AddProject(string email, ProjectProfilePage project)
        {
            var context = new CrowDoDbContext();
            var projectExists = context.Set<ProjectProfilePage>().Where(p => p.Title == project.Title).Any();
            if (projectExists)
            {
                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Project already exists", Data = false };
            }
            var user = context.Set<User>().Where(c => c.Email == email).SingleOrDefault();
            if (user == null)
            {
                return new Result<bool> { ErrorCodeId = 2, ErrorCodeString = "Creator does not exist", Data = false };
            }
            var categoryExists = context.Set<Category>().Where(c => c.Name == project.Category).SingleOrDefault(); ;
            if (categoryExists == null)
            {
                var newCategory = new Category
                {
                    Name = project.Category
                };
                newCategory.Projects.Add(project);
                context.Add(newCategory);
            }
            else
            {
                categoryExists.Projects.Add(project);
                context.Update(categoryExists);
            }

            project.Creator = user;
            user.CreatedProjects.Add(project);
            context.Update(user);
            context.Add(project);
            if (context.SaveChanges() < 1)
            {
                return new Result<bool> { ErrorCodeId = 3, ErrorCodeString = "Not Saved", Data = false };
            }

            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Project created", Data = true };

        }

        public Result<bool> ProjectCreation(string email, string title, string description, DateTime dateOfCreation,
            string category, DateTime deadline, decimal goal)
        {
            var project = new ProjectProfilePage
            {
                Title = title,
                Description = description,
                Balance = 0,
                DateOfCreation = dateOfCreation,
                DeadLine = deadline,
                Goal = goal,
                Category = category

            };

            project.Active = true;

            AddProject(email, project);
            {
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Project created", Data = true };
            }

        }

        public Result<bool> ProjectEdit(string currenttitle, string title, string description, DateTime deadline)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(c => c.Title == currenttitle);
            if (project == null)
            {
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Project not found", Data = false };
            }
            project.Title = title;
            project.Description = description;
            project.DeadLine = deadline;
            context.SaveChanges();

            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Project edited", Data = true };
        }

        public Result<bool> AddVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var newVideo = new Videos
            {
                Name = videoName
            };
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if (project != null)
            {
                project.Videos.Add(newVideo);
                context.SaveChanges();
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = true };
            }
            return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Project Not Found", Data = false };
        }
        public Result<bool> DeleteVideo(string projectName, string videoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var video = context.Set<Videos>().SingleOrDefault(l => l.Name == videoName);
            if (video != null)
            {
                context.Remove(video);
                context.SaveChanges();
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = true }; ;
            }
            return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Video Not Found", Data = false };
        }


        public Result<bool> AddPhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var newPhoto = new Photos
            {
                Name = photoName
            };
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            if (project == null)
            {
                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Project Not Found", Data = true };
            }
            project.Photos.Add(newPhoto);
            context.SaveChanges();
            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = true };
        }

        public Result<bool> DeletePhoto(string projectName, string photoName)
        {
            var context = new CrowDoDbContext();
            var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectName);
            var photo = context.Set<Photos>().SingleOrDefault(l => l.Name == photoName);
            if (photo != null)
            {
                context.Remove(photo);
                context.SaveChanges();
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "OK", Data = true };
            }
            return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Photo Not Found", Data = false };
        }

        //public List<string> CreateCategory(string categoryKeywords, ProjectProfilePage project)
        //{
        //    var context = new CrowDoDbContext();
        //    var punctuation = categoryKeywords.Where(Char.IsPunctuation).Distinct().ToArray();
        //    var words = categoryKeywords.Split().Select(x => x.Trim(punctuation));
        //    var category = context.Set<Category>();
        //    var result = new List<String>();
        //    foreach (var w in words)
        //    {
        //        foreach (var c in category)
        //        {
        //            if (w != c.Name)
        //            {
        //                result.Add(w);
        //                context.SaveChanges();
        //                var categr = context.Set<Category>().SingleOrDefault(ct => ct.Name == w);
        //                int categoryId = categr.CategoryId;
        //                int projectId = project.ProjectProfilePageId;
        //                AddCategory(categoryId, projectId);
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public void AddCategory(int categoryId, int projectId)
        //{
        //    var context = new CrowDoDbContext();
        //    var item = new ProjectCategory
        //    {
        //        ProjectProfilePageId = projectId,
        //        CategoryId = categoryId
        //    };
        //    context.Add(item);
        //    context.SaveChanges();
        //}

        public Result<bool> CreateFundPackages(string title, string description, decimal lowerBound, string reward, string projectTitle)
        {

            var context = new CrowDoDbContext();
            var package = new Package
            {
                Title = title,
                Description = description,
                LowerBound = lowerBound,
                Reward = reward
            };
            context.Package.Add(package);
            context.SaveChanges();
            if (AddPackage(projectTitle, package))
            {
                return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Package Created", Data = true };
            }
            return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Package not Saved", Data = true };
        }

        public bool AddPackage(string projectTitle, Package package)
        {
            using (var context = new CrowDoDbContext())
            {
                var project = context.Set<ProjectProfilePage>().SingleOrDefault(p => p.Title == projectTitle);
                //int packid = package.PackageId;
                //var packg = context.Set<Package>().SingleOrDefault(b => b.PackageId == packid);
               package.Project = project;
                context.Add(package);
                context.SaveChanges();
                return true;
            }
        }



    }


}




