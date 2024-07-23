using AuthServer.Business.Mappers;
using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<AppUserDTO>> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDTO>.Fail(new ErrorDTO(errors, true), 400);
            }

            return Response<AppUserDTO>.Success(ObjectMapper.Mapper.Map<AppUserDTO>(user), 200);
        }

        public async Task<Response<AppUserDTO>> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<AppUserDTO>.Fail("UserName not found", 404, true);
            }

            return Response<AppUserDTO>.Success(ObjectMapper.Mapper.Map<AppUserDTO>(user), 200);
        }
    }
}
