using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;
using AdminDashboard.DBOperations;
using AdminDashboard.Models.ViewModel;

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
        var salesViewModel = new salesViewModel()
        {

            totalOrders = sales.GetSalesDetail("id", "count"),
            monthOrders = sales.GetMonthSalesDetail("id", "count", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            totalProductSales = sales.GetSalesDetail("Quantity", "sum"),
            monthlyProductSales = sales.GetMonthSalesDetail("Quantity", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            totalRevenue = sales.GetSalesDetail("TotalSalesAmount", "sum"),
            monthRevenue = sales.GetMonthSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            totalProfit = sales.GetSalesDetail("GrossIncome", "sum"),
            monthProfit = sales.GetMonthSalesDetail("GrossIncome", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),

            FiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy-MM") + "-31'", 2024),
            pastFiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.AddYears(-1).ToString("yyyy") + "-01-01'", "'" + DateTime.Now.AddYears(-1).ToString("yyyy-MM") + "-31'", 2023),

            branchSales = sales.GetBranchSalesSummary("TotalSalesAmount"),

            dailySales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "cast(getdate() as Date)", "cast(getdate() as Date)"),
            monthSales = sales.GetMonthSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            yearSales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy") + "-12-31'"),

            BranchSales = sales.GetBranchSalesDetail("'" + DateTime.Now.ToString("MMM") + "'", 2024)
        };
        ViewBag.SalesDetail = salesViewModel;
        return View();
    }

    public IActionResult SalesDashboard()
    {
        return View();
    }

    public ActionResult SalesDetail()
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
