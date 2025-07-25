using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserViewModel model)
    {
        if (model.Email == "admin@example.com" && model.Password == "123456")
        {
            // hardcoded credentials
            Response.Cookies.Append("auth", "admin_session");
            return RedirectToAction("Dashboard", "Home");
        }

        return Content("Login failed");
    }

    public IActionResult AdminPanel()
    {
        return Content("Admin content here");
    }

    [HttpPost]
    public IActionResult DeleteUser(string email)
    {
        string sql = "DELETE FROM Users WHERE Email = '" + email + "'";
        // simulate executing raw SQL — SQL Injection vulnerability
        System.IO.File.WriteAllText("log.txt", "Deleted user: " + email); // Logging sensitive info
        return Ok("Deleted");
    }
}
