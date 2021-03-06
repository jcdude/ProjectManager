﻿using System.Data.Entity;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using ProjectManagerDAL.Entities;

namespace ProjectManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string First { get; set; }
        public string Last { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public List<Folder> GetTreeLevelOne()
        {
            using (var db = new ProjectManagerEntities())
            {
                var folders = (from user in db.AspNetUsers
                               join link in db.LinkUserToFolders
                               on user.Id equals link.UserId
                               join folder in db.Folders
                               on link.FolderId equals folder.Id
                               where user.Id == this.Id
                               orderby folder.DateCreated descending
                               select folder);
                return folders.ToList();
            }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}