﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public record AuthenticateResponse(string UserName, string Email, string Token);
}
