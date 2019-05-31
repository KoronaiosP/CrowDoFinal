using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowDo1st;
using Microsoft.AspNetCore.Mvc;

namespace CrowDo1stAPI.Controllers
{
    public struct User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string CardNumber { get; set; }
    }
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService user1 = new UserService();

        //POST CreateAccount
        [HttpPost("createaccount")]
        public Result<bool> Post([FromBody] User user)
        {
          Result<bool> ret=  user1.CreateAccount(user.Name, user.Email, user.DateOfBirth, user.Location, user.CardNumber);
          return ret;
        }

        [HttpPut("DeactivateAccount")]
        public Result<bool> Put([FromBody] User user)
        {
            Result<bool> ret = user1.DeleteAccount(user.Name, user.Email);
            return ret;
        }

        [HttpPut("EditAccount")]
        public Result<bool> EPut([FromBody] User user)
        {
            Result<bool> ret = user1.EditAccount(user.Name, user.Email, user.DateOfBirth, user.Location, user.CardNumber);
            return ret;
        }





    }

    public struct CreatorInfo
    {
        public string Email { get; set; }
        //public string Title { get; set; }


        //public ProjectProfilePage Project { get; set; }
        
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Category { get; set; }
        public DateTime DeadLine { get; set; }
        public string ProjectName { get; set; }
        public string VideoName { get; set; }
        public string PhotoName { get; set; }
        //----------------------------------------------------------------
        public string currentTitle { get; set; }
        public decimal Goal { get; set; }
        //----------------------------------------------------------------
        public string PackageTitle { get; set; }
        public string PackageDescription { get; set; }
        public decimal LowerBound { get; set; }
        public string Reward { get; set; }
        
    }
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectCreatorService projectCreator = new ProjectCreatorService();

        //POST ProjectCreation
        [HttpPost("projectcreation")]
        public Result<bool> Post1([FromBody] CreatorInfo user)
        {
            var res= projectCreator.ProjectCreation(user.Email, user.ProjectName, user.Description, DateTime.Now, user.Category, user.DeadLine,user.Goal);
            return res;
        }

        //POST ProjectCreation
        [HttpPost("EditProject")]
        public Result<bool> Post2([FromBody] CreatorInfo user)
        {
            var res = projectCreator.ProjectEdit(user.currentTitle, user.ProjectName, user.ProjectName, user.DeadLine);
            return res;
        }

        //POST AddVideo
        [HttpPost("project/AddVideo")]
        public Result<bool> Post3([FromBody] CreatorInfo user)
        {
            var res = projectCreator.AddVideo(user.ProjectName, user.VideoName);
            return res;
        }

        //POST AddVideo
        [HttpPost("project/DeleteVideo")]
        public Result<bool> Post4([FromBody] CreatorInfo user)
        {
            var res = projectCreator.DeleteVideo(user.ProjectName, user.VideoName);
            return res;
        }

        //POST AddPhoto
        [HttpPost("project/AddPhoto")]
        public Result<bool> Post5([FromBody] CreatorInfo user)
        {
            var res = projectCreator.AddPhoto(user.ProjectName, user.PhotoName);
            return res;
        }

        [HttpPost("project/DeletePhoto")]
        public Result<bool> Post6([FromBody] CreatorInfo user)
        {
            var res = projectCreator.DeletePhoto(user.ProjectName, user.PhotoName);
            return res;
        }

        
        
        
    }

    public struct Backer
    {
        public string Email { get; set; }
        public string ProjectName { get; set; }
        public decimal Ammount { get; set; }
        public string TitleOfPackage { get; set; }
    }
    [ApiController]
    public class FundController : ControllerBase
    {
        private IBackerService backer = new BackerService();

        //POST FundProject
        [HttpPost("FundProject")]
        public Result<bool> Post([FromBody] Backer user)
        {
            var fund = backer.FundProject(user.Email, user.ProjectName, user.Ammount);
            return fund;
        }

    }

    public struct SearchCriteria
    {
        public string CategoryName { get; set; }
        public string Email { get; set; }
    }
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IViewService service = new ViewService();

        // GET ViewPendingProjects   
        [HttpGet("view/PendingProjects")]
        public ActionResult<Result<List<string>>> Get()
        {
            return service.ViewPendingProjects();
        }
        // GET ViewProjects  
        [HttpGet("Projects")]
        public ActionResult<Result<List<string>>> Get2()
        {
            return service.ViewProjects();
        }
        // GET FundedProjects
        [HttpGet("MyFundedProjects")]
        public ActionResult<Result<List<ProjectProfilePage>>> Get3(string email)
        {
            return service.FundedProjects(email);
        }
        // GET ViewByCategory
        [HttpGet("Projects/ByCategory")]
        public ActionResult<Result<List<string>>> Get4(string categoryName)
        {
            return service.ViewByCategory(categoryName);
        }
        // GET ViewByText
        [HttpGet("Projects/ByText")]
        public ActionResult<Result<List<string>>> Get5(string text)
        {
            return service.ViewByText(text);
        }
        // GET ViewByCreator
        [HttpGet("Projects/ByCreatorName")]
        public ActionResult<Result<List<string>>> Get6(string name)
        {
            return service.ViewByCreator(name);
        }
        // GET ViewByYear
        [HttpGet("View/ByYear")]
        public ActionResult<Result<List<string>>> Get7(int year)
        {
            return service.ViewByYear(year);
        }
        // GET ViewDetailsProject
        [HttpGet("View/Details")]
        public ActionResult<Result<List<string>>> Get8(string title)
        {
            return service.ViewDetailsOfProject(title);
        }

    }

}
