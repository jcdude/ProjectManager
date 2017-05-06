using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class FolderModels
    {
        private Folder folder;
        private ProjectManagerEntities db;

        public FolderModels(string folderId)
        {
            db = new ProjectManagerEntities();
            folder = db.Folders.FirstOrDefault(x => x.Id == folderId);
        }

        
    }
}