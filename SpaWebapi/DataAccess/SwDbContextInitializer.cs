using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SpaWebapi.Models;

namespace SpaWebapi.DataAccess
{
    public class SwDbContextInitializer : DropCreateDatabaseAlways<SwDbContext>
    {
        protected override void Seed(SwDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "ryanspears"))
            {
                var user = AddAdminUser(context);
                AddExpense(context, user);
            }

            base.Seed(context);
        }

        private static User AddAdminUser(IdentityDbContext<User> context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "ryanspears"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "ryanspears", Email = "sperj001@hotmail.com" };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "admin");

                return user;
            }

            return context.Users.First(u => u.UserName == "ryanspears");
        }

        private static void AddExpense(SwDbContext context, User user)
        {
            context.Expenses.AddOrUpdate(
                expense => expense.CreatedDate,
                new Expense
                {
                    CreatedDate = DateTime.Now,
                    Amount = 10023.78m,
                    User = user
                });

            context.SaveChanges();
        }
    }
}