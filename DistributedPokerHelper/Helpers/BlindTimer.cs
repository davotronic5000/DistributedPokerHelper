using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using DistributedPokerHelper.Hubs;
using Microsoft.AspNet.SignalR;

namespace DistributedPokerHelper.Helpers
{
    public class BlindTimer : IRegisteredObject
    {
        private readonly IHubContext _hub;
        private Timer _timer;

        public BlindTimer(IHubContext hub)
        {
            _hub = hub;
            StartTimer();
        }

        public BlindTimer() : this(GlobalHost.ConnectionManager.GetHubContext<BlindTimerHub>()) { }

        public void StartTimer()
        {
            _timer = new Timer(BroadCastTimerState, null, 2, 1);
        }

        private void BroadCastTimerState(object state)
        {
            //TODO: Get start time from DB and totalSeconds
            var startTime = DateTime.UtcNow.AddMinutes(-15);
            var totalSeconds = 900;

            var timeElapsed =  DateTime.UtcNow - startTime;

            _hub.Clients.All.getTimerState(totalSeconds, timeElapsed.TotalSeconds);
        }

        public void Stop(bool immeditate)
        {
            _timer.Dispose();
            HostingEnvironment.UnregisterObject(this);
        }
    }
}