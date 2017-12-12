using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OneOff.Web.MVC.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneOff.Web.MVC.Startup))]
namespace OneOff.Web.MVC
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
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //  create artist role
            if (!roleManager.RoleExists("Artist"))
            {
                var role = new IdentityRole();
                role.Name = "Artist";
                roleManager.Create(role);
            }

            //  create venue role
            if (!roleManager.RoleExists("Venue"))
            {
                var role = new IdentityRole();
                role.Name = "Venue";
                roleManager.Create(role);
            }
        }
    }
}
