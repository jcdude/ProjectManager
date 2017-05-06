using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class ProjectModels
    {
        private Project project;
        private ProjectManagerEntities db;

        public ProjectModels(string projectId)
        {
            db = new ProjectManagerEntities();
            project = db.Projects.FirstOrDefault(x => x.Id == projectId);
        }

        
    }
}