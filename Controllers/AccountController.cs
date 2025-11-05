using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BBB.Data;
using BBB.Models;
using BBB.Services;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {   
        
        User? user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            ViewBag.Error = "Invalid username or password";
            return RedirectToAction("Login", "Account");
        }
        Auth? auth = _context.Auths.FirstOrDefault(a => a.UserId == user.Id);
        if (auth == null)
        {
            ViewBag.Error = "Invalid username or password";
            return RedirectToAction("Login", "Account");
        }

        if (PBKDF2Hasher.Verify(password, auth.PasswordHash, auth.Token ?? ""))
        {
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Error = "Invalid username or password";
        return RedirectToAction("Login", "Account");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    
    public IActionResult Register()
    {
        return View();
    }
}