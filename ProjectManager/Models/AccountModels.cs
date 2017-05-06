using ProjectManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class AccountModels
    {
        private AspNetUser folder;
        private ProjectManagerEntities db;

        public AccountModels(string accountId)
        {
            db = new ProjectManagerEntities();
            folder = db.AspNetUsers.FirstOrDefault(x => x.Id == accountId);
        }

        public static List<ManagerUserListItem> getAllUsers()
        {
            using (var pMEtities = new ProjectManagerEntities())
            {
                var users = from user in pMEtities.AspNetUsers
                            select new ManagerUserListItem() { Id = user.Id, FullName = string.Concat(user.First, " ", user.Last) };
                return users.ToList();
            }
        }
    }
}