using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.ViewModels
{
    public class VmLogin
    {
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
