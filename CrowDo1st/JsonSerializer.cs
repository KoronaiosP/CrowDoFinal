using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrowDo1st
{
    public class JsonSerializer
    {
        public void ReadProjectFromFile(string fileName)
        { //Create new project

            using (StreamReader r = new StreamReader($@"{fileName}.json"))
            {
                string json = r.ReadToEnd();
                List<ProjectFromFile> projectsFromFile = JsonConvert.DeserializeObject<List<ProjectFromFile>>(json);


                var service = new ProjectCreatorService();
                foreach (ProjectFromFile p in projectsFromFile)
                {
                    var project = new ProjectProfilePage
                    {
                        Title = p.NameOfProject,
                        Description = p.Description,
                        Category = p.Keywords,
                        Goal = p.Demandedfunds,
                        DateOfCreation = DateTime.Parse(p.DateOfCreation),
                        DeadLine = DateTime.Parse(p.Deadline),
                        
                        
                    };
                    project.Active = true;
                    service.AddProject(p.Creator, project);

                }


            }

        }
        public void ReadCreatorFromFile(string fileName)
        { //Create new project
            using (StreamReader r = new StreamReader($@"{fileName}.json"))
            {
                string json = r.ReadToEnd();
                List<CreatorFromfile> creatorsFromFile = JsonConvert.DeserializeObject<List<CreatorFromfile>>(json);
                var users = new List<User>();

                foreach (CreatorFromfile c in creatorsFromFile)
                {
                    var user = new User
                    {
                        Name = c.Name,
                        Email = c.Email,
                        Location = c.Address,
                    };
                    users.Add(user);

                }
                var context = new CrowDoDbContext();
                foreach (User u in users)
                {
                    context.Add(u);
                    context.SaveChanges();
                }

            }
        }

    }
}