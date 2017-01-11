using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class FolderModel
    {

        public List<Folder> getLevelOne(ApplicationUser User)
        {
            using (var db = new ProjectManagerEntities())
            {
                var folders = from userLink in db.LinkUserToFolders
                              join folder in db.Folders
                              on userLink.FolderId equals folder.Id
                              where userLink.UserId == User.Id
                              && folder.LinkProjectToFolders.Count == 0
                              select folder;

                return folders.ToList();
            }
        }
    }
}