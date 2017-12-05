﻿using System;
using FluentValidator;

namespace LuizaEM.Domain.Commands.UserCommands
{
    public class UserCommand 
    {
        public string Username { get; set; }
        public string Email { get; set; }

        // public string Password { get; set; }
        public int Permission { get; set; }
        public bool Active { get; set; }

       
    }
}
