using System;
using System.Collections.Generic;
using System.Text;

namespace CrowDo1st
{
    public interface IProjectCreatorService
    {
        Result<bool> ProjectCreation(string email, string title, string description, DateTime dateOfCreation, string category, DateTime deadline, decimal goal);
        //Result<bool> AddProject(string email, ProjectProfilePage project);
        Result<bool> ProjectEdit(string currenttitle, string title, string description, DateTime datetime);
        Result<bool> AddVideo(string projectName, string videoName);
        Result<bool> DeleteVideo(string projectName, string videoName);
        Result<bool> AddPhoto(string projectName, string photoName);
        Result<bool> DeletePhoto(string projectName, string photoName);


    }
}
