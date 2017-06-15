using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DistributedPokerHelper.Controllers
{
    public abstract class ApiControllerWithHub<THub> : ApiController where THub: IHub
    {
        private readonly Lazy<IHubContext> _hub;

        protected ApiControllerWithHub()
        {
            _hub = new Lazy<IHubContext>(
                () => GlobalHost.ConnectionManager.GetHubContext<THub>());
        }
    }
}