using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using skbnjayapura.Shared;

namespace skbnjayapura.Server.Service.AuthService;
public interface IAccountService 
{
    Task<IdentityUser> FindUserById(string id);
    Task<AuthenticateResponse> Login(LoginRequest model);
    Task<AuthenticateResponse> Register(RegisterRequest requst);
    Task AddUserRole(string v, IdentityUser user);
    Task<IdentityUser> FindUserByUserName(string userName);
    Task<IdentityUser> FindUserByEmail(string email);
    Task<IEnumerable<IdentityUser>> GetUsers();
}

