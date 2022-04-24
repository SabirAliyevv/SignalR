using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalR.Data;
using SignalR.Models;
using SignalR.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(AppDbContext context,UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            List<CustomUser> users = _context.CustomUsers.Where(u => u.Id != _userManager.GetUserId(User)).ToList();
            return View(users);
        }

        public IActionResult Chat(string reciverid)
        {
            string senderid = _userManager.GetUserId(User);
            VmChat model = new VmChat();
            model.Reciever = _context.CustomUsers.Find(reciverid);
            model.Messages = _context.Messages.Where(m => (m.SenderId == senderid && m.ReciverId == reciverid) ||
                                                          (m.SenderId ==reciverid && m.ReciverId == senderid))
                                              .ToList();
            return View(model);
        }
 
    }
}
