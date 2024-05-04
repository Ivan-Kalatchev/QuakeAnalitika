using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using QuakeAnalitika.Services;
using QuakeAnalitika.Model.Open;

namespace QuakeAnalitika.Controllers;

[Route("[controller]")]
public class LoginController : Controller
{
    #region Fields

    private readonly ILogger<LoginController> _Logger;
    private readonly IUserRepository _UsersRepo;

    #endregion

    #region C-tros

    /// <summary>
    /// Default DI constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="cont"></param>
    /// <param name="tc"></param>
    /// <param name="cfg"></param>
    public LoginController(ILogger<LoginController> logger, IUserRepository usersRepo)
    {
        // Dependency injection

        _Logger = logger;
        _UsersRepo = usersRepo;
    }

    #endregion

    #region Actions

    /// <summary>
    /// View for login.
    /// 
    /// GET: /login
    /// </summary>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet()]
    public IActionResult Index()
    {
        if (!string.IsNullOrEmpty(User?.Identity?.Name))
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        return View("Login");
    }

    /// <summary>
    /// Logs the user and sets future needed cookies.
    /// 
    /// POST: /login/login
    /// </summary>
    /// <param name="cred"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] CredentialsDto cred)
    {
        // initial checks
        if (cred is null || !cred.HasData()) return Unauthorized("Incorrect passowrd/username.");

        // Authentication
        _Logger.LogInformation($"Auth started for user {cred.UserName} at {DateTime.UtcNow}.");

        // check for user existence
        var usr = await _UsersRepo.AuthenticateUserAsync(cred.UserName, cred.Password);
        if (usr is null) return Unauthorized("Incorrect username/password");

        _Logger.LogInformation($"Password matching for user with username: {cred.UserName} at {DateTime.UtcNow}.");

        // cookies
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, cred.UserName),
            new Claim("UserId", cred.UserName),
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { });
        _Logger.LogInformation($"Auth finished for user with username: {cred.UserName} at {DateTime.UtcNow}.");
        return Ok();
    }

    /// <summary>
    /// Logs out the user as it destroys the session.
    /// 
    /// GET: /login/logout
    /// </summary>
    /// <returns></returns>
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        // logout process
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        // log action
        _Logger.LogInformation($"User {User?.Identity?.Name} logged out at {DateTime.UtcNow}.");
        // everything went ok : redirect to /login
        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
    }

    #endregion
}
