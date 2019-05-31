using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowDo1st
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var context = new CrowDoDbContext();
            //UserService us = new UserService();
            //us.CreateAccount = 

            // var service = new ProjectCreatorService();
            //var userservice = new UserService();
            //userservice.CreateAccount("George Nikolaou", "k@Outlook.com", new DateTime(1999, 3, 26), "Athens", "5168790076652351");


            //var jsonserializer = new JsonSerializer();
            ////jsonserializer.ReadCreatorFromFile("Creators_info");
            //jsonserializer.ReadProjectFromFile("Initial_data_for_your_project");
            //var services = new ProjectCreatorService();
            //services.ProjectCreation("KoronaiosP@Outlook.com", "TitleNo1", "Bendir", new DateTime(2012, 03, 26),"music", new DateTime(2000, 04, 26));
            //services.ProjectCreation("alpha@gmail.com", "new title new1title", "mydescr", new DateTime(2018, 05, 23), "Health Fitness", new DateTime(2018, 05, 23));
            //services.ProjectCreation("KoronaiosP@Outlook.com","Ti_le","elevator", new DateTime(2018, 05, 23), "Engineering", new DateTime(2018, 05, 23));
            //services.ProjectEdit("TitleNo1", "TITLEEEE", "DRUMMMMMMSSSSS", new DateTime(5000, 04, 26));
            //services.AddVideo("TITLEEEE", "Koronaios_Solo");
            //services.DeleteVideo("TITLEEEE", "Koronaios_Solo");
            //services.DeletePhoto("TITLEEEE", "Koronaios_Solo.JPG");
            var view = new ViewService();
            view.ViewByYear(2012);
            //view.ViewProjects();
            //var service = new BackerService();
            //service.BackersFundedProjects("KoronaiosP@Outlook.com");

            //userservice.DeleteAccount("Panagiotis", "KoronaiosP@Outlook.com");
            ////var p1 = new ProjectProfilePage
            ////{
            ////    Title= "MyTitle",
            ////    Description="elevator",
            ////    DateOfCreation= new DateTime(2018, 05, 23),
            ////    Category= "Engineering",
            ////    DeadLine= new DateTime(2018, 05, 23)
            //var serviceb = new BackerService();
            //serviceb.FundProject("KoronaiosP@Outlook.com", "Ballacio", 10000);


            //};
            //var p2 = new ProjectProfilePage
            //{
            //    Title = "MyTitleeeee",
            //    Description = "elevatorrrrr",
            //    DateOfCreation = new DateTime(2018, 05, 23),
            //    Category = "Health Fitness",
            //    DeadLine = new DateTime(2018, 05, 23)

            //};
            //Projects.Add(p1);
            //Projects.Add(p2);
            ////var bs = new BackerService();
            //var reporting = new ReportingServices();
            //reporting.SaveToXls("Panagiotis", Projects);



        }

    }
}
