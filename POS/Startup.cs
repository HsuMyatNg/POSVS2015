using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using POS.Models;
using System;

[assembly: OwinStartupAttribute(typeof(POS.Startup))]
namespace POS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateInitialRole();
        }
        public void CreateInitialRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!context.Database.Exists())
            {
                #region Create Roles
                var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
                //if (!roleManager.RoleExists("Admin")) { }                              
                roleManager.Create(new IdentityRole() { Name = "Admin" });
                roleManager.Create(new IdentityRole() { Name = "Staff" });
                #endregion

                #region create admin 
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var adminUser = new ApplicationUser() { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                string userPassword = "Admin@123";
                var chkUser = userManager.Create(adminUser, userPassword);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(adminUser.Id, "Admin");
                }


                var staffUser = new ApplicationUser() { UserName = "staff@gmail.com", Email = "staff@gmail.com" };
                string staffUserPWD = "Staff@123";
                chkUser = userManager.Create(staffUser, staffUserPWD);//only user create
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(staffUser.Id, "Staff");
                }
                #endregion
              
            }
        }
    }
}
