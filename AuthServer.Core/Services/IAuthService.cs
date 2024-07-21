using AuthServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthService
    {
        Task<Response<TokenDTO>> CreateToken(LoginDTO loginDto);
        Task<Response<TokenDTO>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDTO>> RevokeRefreshToken(string refreshToken);
        Task<Response<ClientTokenDTO>> CreateTokenByClient(ClientLoginDTO clientLogin);
    }
}
