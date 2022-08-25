using HR_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace HR_Management.Hubs
{
    public class MercuryHub:Hub
    {
        private UserManager<EmployeeUser> _userManager { get; }

        public MercuryHub(UserManager<EmployeeUser> userManager)
        {
            _userManager = userManager;
        }
        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var loggedUser = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;

                if (loggedUser != null)
                {
                    loggedUser.ConnectionId = Context.ConnectionId;
                    loggedUser.DisconnectedAt = null;
                }
                var result = _userManager.UpdateAsync(loggedUser).Result;

                Clients.All.SendAsync("showAsOnline", loggedUser.Id);
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var loggedUser = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;

                if (loggedUser != null)
                {
                    loggedUser.ConnectionId = null;
                    loggedUser.DisconnectedAt = DateTime.Now;
                }
                var result = _userManager.UpdateAsync(loggedUser).Result;

                Clients.All.SendAsync("showAsOffline", loggedUser.Id);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
