using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMessage : Controller
{
    public IActionResult InBox()
    {
        return View();
    }
}