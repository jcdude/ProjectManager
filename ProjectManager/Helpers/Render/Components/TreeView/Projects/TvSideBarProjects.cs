using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectManager.Helpers.Render.Components.TreeView.Folders
{
    public class TvSideBarProjects : CustomTreeView
    {
        public ProjectManagerEntities db;

        public TvSideBarProjects(string parentLiFormat, string childLiFormat) : base(parentLiFormat, childLiFormat)
        {
            db = new ProjectManagerEntities();
        }

        //Get projects for a specific folder
        public string projectsByFolder(string folderId)
        {
            var sb = new StringBuilder();
            
            var projects = (from link in db.LinkProjectToFolders
                            join project in db.Projects
                            on link.ProjectId equals project.Id
                            where link.FolderId == folderId
                            select project);

            foreach (var project in projects)
            {
                sb.AppendFormat(liParent, project.Description);
            }

            return sb.ToString();
        }

        //Get projects for a specific project
        public string projectsByProject(string projectId)
        {
            var sb = new StringBuilder();
            
            var projectByProject = (from link in db.LinkProjectToProjects
                                    join project in db.Projects
                                    on link.ProjectId equals project.Id
                                    where link.ProjectId == projectId
                                    select project);

            foreach (var project in projectByProject)
            {
                sb.AppendFormat(liParent, project.Description);
            }

            return sb.ToString();
        }

        //Get projects for a specific task
        public string projectsByTask(string taskId)
        {
            var sb = new StringBuilder();
            
            var projectByProject = (from link in db.LinkProjectToTasks
                                    join project in db.Projects
                                    on link.ProjectId equals project.Id
                                    where link.TaskId == taskId
                                    select project);

            foreach (var project in projectByProject)
            {
                sb.AppendFormat(liParent, project.Description);
            }

            return sb.ToString();
        }
    }
}