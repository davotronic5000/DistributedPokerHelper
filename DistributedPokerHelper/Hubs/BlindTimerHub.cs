using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DistributedPokerHelper.Context;
using DistributedPokerHelper.Entities;
using Microsoft.AspNet.SignalR;

namespace DistributedPokerHelper.Hubs
{
    public class BlindTimerHub : Hub
    {
        public override async Task OnConnected()
        {
            using (var context = new ApplicationContext())
            {
                context.TournamentEntitySet.Add(new TournamentEntity
                {
                    Name = "Dave's Game"
                });
            }
        }
    }
}