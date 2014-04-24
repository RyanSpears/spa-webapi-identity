using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpaWebapi.Models;

namespace SpaWebapi.DataAccess
{
    public class SwDbContextInitializer : DropCreateDatabaseAlways<SwDbContext>
    {
        protected override void Seed(SwDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string name = "ryanspears";
            const string password = "password";
            const string email = "sperj001@hotmail.com";
            const string admin = "Admin";

            // Create Admin role and User
            roleManager.Create(new IdentityRole(admin));
            //UserManager.Create(new User { UserName = name, Email = email});

            //Create Role Admin if it does not exist
            if (!roleManager.RoleExists(name))
            {
                var roleresult = roleManager.Create(new IdentityRole(admin));
            }

            //Create User=ryanspears with password=password
            var user = new User { UserName = name, Email = email };
            var adminresult = userManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, name);
            }

            base.Seed(context);
        }
    }
}