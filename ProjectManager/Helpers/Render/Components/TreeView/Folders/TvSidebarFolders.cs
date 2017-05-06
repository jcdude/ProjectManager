using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectManager.Helpers.Render.Components.TreeView.Folders
{
    public class TvSidebarFolders : CustomTreeView
    {
        public ProjectManagerEntities db;

        public TvSidebarFolders(string parentLiFormat, string childLiFormat) : base(parentLiFormat, childLiFormat)
        {
            db = new ProjectManagerEntities();
        }

        public string treeLevelOne(string userId)
        {
            var sb = new StringBuilder();

            var folders = (from user in db.AspNetUsers
                            join link in db.LinkUserToFolders
                            on user.Id equals link.UserId
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where user.Id == userId
                            select folder);

            foreach (var folder in folders)
            {
                sb.AppendFormat(liParent, folder.Description);
            }

            return sb.ToString();
        }

        //Get folders for a specific folder
        public string foldersByFolder(string folderId)
        {
            var sb = new StringBuilder();

            var folders = (from link in db.LinkFolderToFolders
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where link.FolderId == folderId
                            select folder);

            foreach (var folder in folders)
            {
                sb.AppendFormat(liParent, folder.Description);
            }

            return sb.ToString();
        }

        //Get folders for a specific project
        public string foldersByProject(string projectId)
        {
            var sb = new StringBuilder();

            var folders = (from link in db.LinkFolderToProjects
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where link.ProjectId == projectId
                            select folder);

            foreach (var folder in folders)
            {
                sb.AppendFormat(liParent, folder.Description);
            }


            return sb.ToString();
        }

        //Get folders for a specific task
        public string foldersByTask(string taskId)
        {
            var sb = new StringBuilder();
            
            var folders = (from link in db.LinkFolderToTasks
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where link.TaskId == taskId
                            select folder);

            foreach (var folder in folders)
            {
                sb.AppendFormat(liParent, folder.Description);
            }

            return sb.ToString();
        }
    }
}