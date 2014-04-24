using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using SpaWebapi.Models;

namespace SpaWebapi.DataAccess
{
    public class SwDbContext : IdentityDbContext<User>
    {
        public SwDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Sample data if debug (remove in prd)
#if DEBUG
            Database.SetInitializer(new SwDbContextInitializer());
#else
            Database.SetInitializer(null);
#endif

            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Create all indexes
            base.OnModelCreating(modelBuilder);
        }

        private void CreateIndex(string field, Type table)
        {
            Database.ExecuteSqlCommand(String.Format("CREATE INDEX IX_{0} ON {1} ({0})", field, table.Name));
        }   
    }
}