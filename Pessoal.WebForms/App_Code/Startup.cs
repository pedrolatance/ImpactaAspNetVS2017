﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pessoal.WebForms.Startup))]
namespace Pessoal.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
