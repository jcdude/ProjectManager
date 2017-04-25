using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectManager.Helpers.Render.Components
{
    public class SideBar
    {
        public static readonly string liPrimary = "<li>{0}</li>";
        public static readonly string liSecondary = "<li>{0}</li>";

        public static string treeLevelOne(string userId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from user in db.AspNetUsers
                             join link in db.LinkUserToFolders
                             on user.Id equals link.UserId
                             join folder in db.Folders
                             on link.FolderId equals folder.Id
                             where user.Id == userId
                             select folder);

                foreach(var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();                
        }

        #region Projects

        //Get projects for a specific folder
        public static string projectsByFolder(string folderId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var projects = (from link in db.LinkProjectToFolders
                               join project in db.Projects
                               on link.ProjectId equals project.Id
                               where link.FolderId == folderId
                               select project);

                foreach (var project in projects)
                {
                    sb.AppendFormat(liPrimary, project.Description);
                }
            }

            return sb.ToString();
        }

        //Get projects for a specific project
        public static string projectsByProject(string projectId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var projectByProject = (from link in db.LinkProjectToProjects
                                        join project in db.Projects
                                        on link.ProjectId equals project.Id
                                        where link.ProjectId == projectId
                                        select project
                               );

                foreach (var project in projectByProject)
                {
                    sb.AppendFormat(liPrimary, project.Description);
                }
            }

            return sb.ToString();
        }

        //Get projects for a specific task
        public static string projectsByTask(string taskId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var projectByProject = (from link in db.LinkProjectToTasks
                                        join project in db.Projects
                                        on link.ProjectId equals project.Id
                                        where link.TaskId == taskId
                                        select project
                               );

                foreach (var project in projectByProject)
                {
                    sb.AppendFormat(liPrimary, project.Description);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Folders

        //Get folders for a specific folder
        public static string foldersByFolder(string folderId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from link in db.LinkFolderToFolders
                               join folder in db.Folders
                               on link.FolderId equals folder.Id
                               where link.FolderId == folderId
                               select folder);

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();
        }

        //Get folders for a specific project
        public static string foldersByProject(string projectId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from link in db.LinkFolderToProjects
                               join folder in db.Folders
                               on link.FolderId equals folder.Id
                               where link.ProjectId == projectId
                               select folder);

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();
        }

        //Get folders for a specific task
        public static string foldersByTask(string taskId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from link in db.LinkFolderToTasks
                               join folder in db.Folders
                               on link.FolderId equals folder.Id
                               where link.TaskId == taskId
                               select folder);

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();
        }

        #endregion

        #region Tasks

        //Get tasks for a specific folder
        public static string tasksByFolder(string folderId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var taskByFolder = (from link in db.LinkFolderToTasks
                                    join tasks in db.Tasks
                                    on link.TaskId equals tasks.Id
                                    where link.FolderId == folderId
                                    select tasks
                               );

                foreach (var task in taskByFolder)
                {
                    sb.AppendFormat(liPrimary, task.Description);
                }
            }

            return sb.ToString();
        }

        //Get tasks for a specific project
        public static string tasksByProject(string projectId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from link in db.LinkProjectToTasks
                               join tasks in db.Tasks
                               on link.TaskId equals tasks.Id
                               where link.ProjectId == projectId
                               select tasks
                               );

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();
        }

        //Get tasks for a specific project
        /*public static string tasksByProject(int projectId)
        {
            var sb = new StringBuilder();

            using (var db = new ProjectManagerEntities())
            {
                var folders = (from user in db.AspNetUsers
                               join link in db.LinkUserToFolders
                               on user.Id equals link.UserId
                               join folder in db.Folders
                               on link.FolderId equals folder.Id
                               where user.Id == userId
                               select folder);

                foreach (var folder in folders)
                {
                    sb.AppendFormat(liPrimary, folder.Description);
                }
            }

            return sb.ToString();
        }*/

        #endregion

    }
}