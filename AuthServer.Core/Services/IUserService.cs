﻿using AuthServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDTO>> CreateUserAsync(CreateUserDTO createUser);
        Task<Response<AppUserDTO>> GetUserByUserName(string userName);
    }
}