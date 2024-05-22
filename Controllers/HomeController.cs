using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;
using AdminDashboard.DBOperations;

namespace AdminDashboard.Controllers;

public class HomeController : Controller
{
    Sales sales = null;
   
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        sales = new Sales();
        _logger = logger;
    }

    public IActionResult Index()
    {
        var result = sales.GetSalesDetail("TotalSalesAmount");     
        ViewBag.SalesDetail = result;
        return View();
    }

    public IActionResult SalesDashboard()
{
    return View();
}

public ActionResult SalesDetail()
{
    var result = sales.GetSalesDetail("TotalSalesAmount"); 
    ViewBag.SalesDetail = result;
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
