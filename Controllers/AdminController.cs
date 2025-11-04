using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using BBB.Data;

public class AdminController : Controller
{
    
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db)
    {
        _db = db;
    }
    public IActionResult GameForm()
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (!int.TryParse(userId, out var userID))
            return RedirectToAction("Index", "Home");

        var user = _db.Users
            .Where(u => u.Id == userID)
            .Select(u => new { u.Role.Name })
            .FirstOrDefault();

        if (user == null || user.Name != "admin")
            return RedirectToAction("Index", "Home");

        return View();
    }

    public IActionResult ApproveReturn()
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (!int.TryParse(userId, out var userID))
            return RedirectToAction("Index", "Home");

        var user = _db.Users
            .Where(u => u.Id == userID)
            .Select(u => new { u.Role.Name })
            .FirstOrDefault();

        if (user == null || user.Name != "admin")
            return RedirectToAction("Index", "Home");

        return View();
    }

    




}
