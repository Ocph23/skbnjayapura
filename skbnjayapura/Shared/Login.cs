using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
