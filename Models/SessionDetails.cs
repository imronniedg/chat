using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class SessionDetails
    {
        public string? IPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public SessionType SessionType { get; set; }
    }

    public enum SessionType { Server, Client}
}
