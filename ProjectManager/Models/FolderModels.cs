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

        public FolderModels(string folderId, ProjectManagerEntities db)
        {
            this.db = db;
            folder = db.Folders.FirstOrDefault(x => x.Id == folderId);
        }

        public IList<Folder> GetFoldersByFolder()
        {
            var folders = (from link in db.LinkFolderToFolders
                            join folder in db.Folders
                            on link.FolderId equals folder.Id
                            where link.FolderId == folder.Id
                            select folder);
            return folders.ToList();
        }
        
    }
}