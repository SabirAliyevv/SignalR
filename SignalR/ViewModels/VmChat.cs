using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.ViewModels
{
    public class VmChat
    {
        public CustomUser Reciever { get; set; }
        public List<Message> Messages { get; set; }
    }
}
