using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalR.Data;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class ChatHub:Hub
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ChatHub(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }



        public async Task SendPrivate(string reciverid, string senderid, string message)
        {
            await Clients.User(reciverid).SendAsync("ReceiveMessage", senderid, message);
            Message newMessage = new Message();
            newMessage.Text = message;
            newMessage.SenderId = senderid;
            newMessage.ReciverId = reciverid;

            _context.Messages.Add(newMessage);
            _context.SaveChanges();

            //await Clients.All.SendAsync("ReceiveMessage", reciverid, message);
        }
    }
}
