﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SpaWebapi.Startup))]

namespace SpaWebapi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
