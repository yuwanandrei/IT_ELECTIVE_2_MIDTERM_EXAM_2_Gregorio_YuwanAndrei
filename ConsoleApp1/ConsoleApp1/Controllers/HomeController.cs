using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "PatientVisit");
        }

        return RedirectToAction("Login", "Account");
    }

    public IActionResult Error()
    {
        return View();
    }
}
