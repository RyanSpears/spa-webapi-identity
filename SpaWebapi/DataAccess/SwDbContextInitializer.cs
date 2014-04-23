using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpaWebapi.DataAccess
{
    public class SwDbContextInitializer : DropCreateDatabaseAlways<SwDbContext>
    {
    }
}