using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class TaskModels
    {
        private Task task;
        private ProjectManagerEntities db;

        public TaskModels(string taskId)
        {
            db = new ProjectManagerEntities();
            task = db.Tasks.FirstOrDefault(x => x.Id == taskId);
        }

        public IList<Folder> foldersByProject()
        {
            var folders = (from link in db.LinkFolderToTasks
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where link.TaskId == task.Id
                            select folder);
            return folders.ToList();
        }
    }
}