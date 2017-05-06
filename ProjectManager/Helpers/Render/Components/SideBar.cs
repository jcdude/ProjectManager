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

        

        #endregion

        #region Folders

        

        #endregion

        #region Tasks

        

        #endregion

    }
}