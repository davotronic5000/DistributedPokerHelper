using Microsoft.AspNet.SignalR;
using Owin;

namespace DistributedPokerHelper
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/api", new HubConfiguration());
        }
    }
}