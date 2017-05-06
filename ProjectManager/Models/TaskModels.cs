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

        
    }
}