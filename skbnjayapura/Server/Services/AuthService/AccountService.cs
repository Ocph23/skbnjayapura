using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using skbnjayapura.Server.Datas;
using skbnjayapura.Shared;
using skbnjayapura.Server.Services.AuthService;

namespace skbnjayapura.Server.Service.AuthService;


public class AccountService : IAccountService
{
    private readonly AppSettings _appSettings;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    public AccountService(IOptions<AppSettings> appSettings, 
        UserManager<IdentityUser>
        _userManager, SignInManager<IdentityUser> _signInManager)
    {
        _appSettings = appSettings.Value;
        userManager = _userManager;
        signInManager = _signInManager;
    }

    public async Task<AuthenticateResponse> Login(LoginRequest model)
    {
        try
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName.ToUpper(), model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(model.UserName);
                var roles = await userManager.GetRolesAsync(user);
                var token = await user.GenerateToken(_appSettings,roles);
                return new AuthenticateResponse(user.UserName, user.Email, token);

            }
            throw new SystemException($"Your Account {model.UserName} Not Have Access !");
        }
        catch (System.Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public async Task<AuthenticateResponse> Register(RegisterRequest requst)
    {
        try
        {
            IdentityUser user = new IdentityUser { Email = requst.Email, UserName = requst.Email, EmailConfirmed = true };
            var userCreated = await userManager.CreateAsync(user, requst.Password);
            if (userCreated.Succeeded)
            {
                if (!string.IsNullOrEmpty(requst.Role))
                {
                    await userManager.AddToRoleAsync(user, requst.Role);
                }
                var token = await user.GenerateToken(_appSettings, new List<string> {requst.Role});
                return new AuthenticateResponse(user.UserName, user.Email, token);
            }

            string errorMessage = string.Empty;
            if (userCreated.Errors.Count() > 0)
            {
                errorMessage = userCreated.Errors.FirstOrDefault().Description;
            }

            throw new SystemException(errorMessage);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<IdentityUser> FindUserById(string id)
    {
        throw new NotImplementedException();
    }

  
    public Task AddUserRole(string v, IdentityUser user)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityUser> FindUserByUserName(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityUser> FindUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IdentityUser>> GetUsers()
    {
        throw new NotImplementedException();
    }
}

