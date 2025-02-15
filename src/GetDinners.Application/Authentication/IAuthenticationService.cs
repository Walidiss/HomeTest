﻿using GetDinners.Application.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDinners.Application.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password );
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
