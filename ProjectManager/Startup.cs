using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ProjectManager.Models;

[assembly: OwinStartupAttribute(typeof(ProjectManager.Startup))]
namespace ProjectManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roles = new string[] { "Anon", "Default", "User", "Admin" };

            foreach (var roleName in roles)
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                if (!roleManager.RoleExists(roleName))
                {
                    role.Name = roleName;
                    roleManager.Create(role);
                }
            }           

            if (!roleManager.RoleExists("AccountHolder"))
            {
                var user = new ApplicationUser();

                var roleAccountHolder = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                roleAccountHolder.Name = "AccountHolder";
                roleManager.Create(roleAccountHolder);

                user.UserName = "admin";
                user.Email = "admin@admin";

                string userPWD = "admin";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "AccountHolder");
                }
            }
        }
    }
}
