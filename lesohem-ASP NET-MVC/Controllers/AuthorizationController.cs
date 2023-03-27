using lesohem_ASP_NET_MVC.DataBase;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AuthorizationController : Controller
{
    public IActionResult Login() => View();
    [HttpPost]
    public async Task<IResult> LoginLocation(User data)
    {
        User user = LoginValidation(data);
        if (user == null)
            return Results.Json(new { message = "Такого пользователя нет!" });
        await RegisterUser(user);
        return Results.Redirect("/Home/Index");
    }

    // Проверка, есть ли такой пользователь в БД
    private User LoginValidation(User data)
    {
        lesohemContext db = new();
        User? user = db.Users.FirstOrDefault(u => u.UserLogin == data.UserLogin && u.UserPassword == data.UserPassword);
        return user!;
    }

    // Если такой пользователь есть, добавляем некоторые данные в куки
    public async Task RegisterUser(User user)
    {
        var claim = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserLogin!),
            new Claim(ClaimTypes.Role, user.UserRole!),
            new Claim("id", user.Id.ToString())
        };
        var identity = new ClaimsIdentity(claim, "Cookies");
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }
}