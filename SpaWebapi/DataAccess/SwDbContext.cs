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
    }
}