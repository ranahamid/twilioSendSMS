using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(twilioSendSMS02.Startup))]
namespace twilioSendSMS02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
