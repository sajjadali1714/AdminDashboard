using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;

namespace AdminDashboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SalesDashboard()
{
    return View();
}

public IActionResult SalesDetail()
{
    return View();
}

public IActionResult ProductDashboard()
{
    return View();
}


public IActionResult ProductDetail()
{
    return View();
}

public IActionResult CustomerDashboard()
{
    return View();
}

public IActionResult CustomerDetail() 
{
    return View();
}

public IActionResult ProductIndex()
{
    return View();
}

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
