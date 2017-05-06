using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectManager.Helpers.Render.Components.TreeView.Folders
{
    public class TvSidebarTasks : CustomTreeView
    {
        public ProjectManagerEntities db;

        public TvSidebarTasks(string parentLiFormat, string childLiFormat) : base(parentLiFormat, childLiFormat)
        {
            db = new ProjectManagerEntities();
        }

        //Get tasks for a specific folder
        public string tasksByFolder(string folderId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var taskByFolder = (from link in db.LinkFolderToTasks
                                    join tasks in db.Tasks
                                    on link.TaskId equals tasks.Id
                                    where link.FolderId == folderId
                                    select tasks);

                foreach (var task in taskByFolder)
                {
                    sb.AppendFormat(liChild, task.Description);
                }
            }

            return sb.ToString();
        }

        //Get tasks for a specific project
        public string tasksByProject(string projectId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from link in db.LinkProjectToTasks
                               join tasks in db.Tasks
                               on link.TaskId equals tasks.Id
                               where link.ProjectId == projectId
                               select tasks);

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liChild, folder.Description);
                }
            }

            return sb.ToString();
        }

        //Get tasks for a specific project
        public string tasksByTask(int taskId)
        {
            var sb = new StringBuilder();
           
            /*var folders = ((from link in db.Link
                            join tasks in db.Tasks
                            on link.TaskId equals tasks.Id
                            where link.ProjectId == projectId
                            select tasks);

            foreach (var folder in folders)
            {
                sb.AppendFormat(liPrimary, folder.Description);
            }*/

            return sb.ToString();
        }
    }
}