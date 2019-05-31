using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CrowDo1st
{
    public class ReportingServices : IReportingServices
    {
        public List<ProjectProfilePage> RecentProjects()
        {
            DateTime lastYear = DateTime.Today.AddYears(-1);
            var context = new CrowDoDbContext();
            var recentProjects = context.Set<ProjectProfilePage>().Where(p => DateTime.Compare(lastYear, p.DateOfCreation) < 0).ToList();
            return recentProjects;
        }

        public List<ProjectProfilePage> MostVisitedProjects()
        {
            var context = new CrowDoDbContext();
            var topCreators = context.Set<ProjectProfilePage>()
               .OrderByDescending(u => u.ViewsCounter)
               .Take(5)
               .ToList();
            return topCreators;
        }
        public List<User> TopCreators()
        {
            var context = new CrowDoDbContext();
            var topCreators = context.Set<User>()
               .OrderByDescending(u => u.ViewsCounter)
               .Take(20)
               .ToList();
            return topCreators;
        }
        public List<ProjectProfilePage> WeeklyProjectsToXls()
        {
            DateTime aWeekAgo = DateTime.Today.AddDays(-7);
            var context = new CrowDoDbContext();
            var lastWeekProjects = context.Set<ProjectProfilePage>().Where(p => DateTime.Compare(aWeekAgo, p.DateOfCreation) < 0).ToList();
            SaveToXls("WeeklyProjects", lastWeekProjects);
            return lastWeekProjects;
        }
        public List<ProjectProfilePage> MonthlyProjectsToXls()
        {
            DateTime aMonthAgo = DateTime.Today.AddDays(-30);
            var context = new CrowDoDbContext();
            var lastWeekProjects = context.Set<ProjectProfilePage>().Where(p => DateTime.Compare(aMonthAgo, p.DateOfCreation) < 0).ToList();
            SaveToXls("WeeklyProjects", lastWeekProjects);
            return lastWeekProjects;
        }
        public bool SaveToXls(string ExcelFileName,List<ProjectProfilePage>projects)
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Sheet");
            
            int x = 0;
            var r1 = sheet.CreateRow(0);
            r1.CreateCell(0).SetCellValue("Title");
            r1.CreateCell(1).SetCellValue("Description");
            r1.CreateCell(2).SetCellValue("Date Of Creation");
            r1.CreateCell(3).SetCellValue("Deadline");
            r1.CreateCell(4).SetCellValue("Balance");
            r1.CreateCell(5).SetCellValue("Goal");
            r1.CreateCell(6).SetCellValue("ViewsCounter");
            r1.CreateCell(7).SetCellValue("Category");
            
            foreach (ProjectProfilePage project in projects)
            {
                x++;
                var row = sheet.CreateRow(x);
                row.CreateCell(0).SetCellValue(project.Title);
                row.CreateCell(1).SetCellValue(project.Description);

                string date = project.DateOfCreation.ToString("yyyy/M/dd "); //Convertion of DateTime To String
                row.CreateCell(2).SetCellValue(date);

                string deadline = project.DateOfCreation.ToString("yyyy/M/dd "); //Convertion of DateTime To String
                row.CreateCell(3).SetCellValue(deadline);

                double balance = (double)Convert.ChangeType(project.Balance, typeof(double)); //Convertion of decimal to double
                row.CreateCell(4).SetCellValue(balance);

                double goal = (double)Convert.ChangeType(project.Goal, typeof(double)); //Convertion of decimal to double
                row.CreateCell(5).SetCellValue(goal);

                string views = (string)Convert.ChangeType(project.ViewsCounter, typeof(string)); //Convertion of integer to string
                row.CreateCell(6).SetCellValue(views);

                row.CreateCell(7).SetCellValue(project.Category);
            }

            using (var fs = new FileStream($"{ExcelFileName}.xlsx", FileMode.Create,
            FileAccess.Write))
            {
                wb.Write(fs);
            }
            return true;
        }

    }
}
