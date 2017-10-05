using System;
using Betgo.Models;
using Betgo.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Betgo.Startup))]
namespace Betgo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole {Name = "Administrator"};
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "vghgergely@gmail.com",
                    Name = "Gergo",
                    Email = "vghgergely@gmail.com",
                    Money = 5000
                };

                string userPw = "AbcdÄ12";

                var chkUser = userManager.Create(user, userPw);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }

            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole {Name = "User"};
                roleManager.Create(role);
            }
        }
    }
}
