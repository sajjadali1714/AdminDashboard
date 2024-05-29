using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;
using AdminDashboard.DBOperations;
using AdminDashboard.Models.ViewModel;

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

        var sales = new Sales();
        var ProductDashboard = new ProductDashboard();
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

            YearTotalSales = sales.GetYearMonthSales("TotalSalesAmount", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy-MM") + "-31'", 2024),
            pastYearTotalSales = sales.GetYearMonthSales("TotalSalesAmount", "'" + DateTime.Now.AddYears(-1).ToString("yyyy") + "-01-01'", "'" + DateTime.Now.AddYears(-1).ToString("yyyy") + "-12-31'", 2023),

            FiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy-MM") + "-31'", 2024),
            pastFiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.AddYears(-1).ToString("yyyy") + "-01-01'", "'" + DateTime.Now.AddYears(-1).ToString("yyyy-MM") + "-31'", 2023),

            branchSales = sales.GetBranchSalesSummary("TotalSalesAmount"),

            dailySales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "cast(getdate() as Date)", "cast(getdate() as Date)"),
            monthSales = sales.GetMonthSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            yearSales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy") + "-12-31'"),
            CommonPaymentMethod = ProductDashboard.GetProductDetail("TotalSalesAmount", "sum", "2024-01-01", "2024-05-26", "", "PaymentTypeName"),
            BranchSales = sales.GetBranchSalesDetail("'" + DateTime.Now.ToString("MMM") + "'", 2024)
        };

        ViewBag.SalesDetail = salesViewModel;
        return View();
    }
    public IActionResult SalesDashboard()
    {
        Sales_Query sales = new Sales_Query();

        var Fashion = sales.GetTotalSalesForCategory("Fashion accessories");
        var Health = sales.GetTotalSalesForCategory("Health and beauty");
        var Sports = sales.GetTotalSalesForCategory("Sports and travel");
        var Food = sales.GetTotalSalesForCategory("Food and beverages");
        var Electronic = sales.GetTotalSalesForCategory("Electronic and accessories");
        var LifeStyle = sales.GetTotalSalesForCategory("Food and beverages");

        ViewBag.Food = Food;
        ViewBag.Sports = Sports; 
        ViewBag.fashion = Fashion;
        ViewBag.Health = Health;
        ViewBag.Electronic = Electronic;
        ViewBag.LifeStyle = LifeStyle;
        return View();
    }

    public ActionResult SalesDetail()
    {
        
        return View();
    }

    public IActionResult ProductDashboard()
    {
        var ProductDashboard = new ProductDashboard();
        var ProductDashboardViewModel = new ProductDashboardViewModel()
        {            
            TotalRevenueProductCategory = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","","ProductCategoryName"),
            PastTotalRevenueProductCategory = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2023-01-01","2023-05-26","","ProductCategoryName"),
            
            TotalOrdersProductCategory = ProductDashboard.GetProductOrderDetail("id","count","2024-01-01","2024-05-26","ProductCategoryName"),
            ProductCategoryByMale = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","And gender = 'Male'","Gender,ProductCategoryName"),
            ProductCategoryByFemale = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","And gender = 'Female'","Gender,ProductCategoryName"),
            CommonPaymentMethod = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","","PaymentTypeName"),
            AverageRatingProductCategory = ProductDashboard.GetProductDetail("Rating","avg","2024-01-01","2024-05-26","","ProductCategoryName"),
            CaliforniaBranchProductCategoryRevenue = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","And BranchName = 'California'","BranchName,ProductCategoryName"),
            FloridaBranchProductCategoryRevenue = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","And BranchName = 'Florida'","BranchName,ProductCategoryName"),
            TexasBranchProductCategoryRevenue = ProductDashboard.GetProductDetail("TotalSalesAmount","sum","2024-01-01","2024-05-26","And BranchName = 'Texas'","BranchName,ProductCategoryName"),

            // totalOrders = sales.GetSalesDetail("id", "count"),
            // monthOrders = sales.GetMonthSalesDetail("id", "count", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            // totalProductSales = sales.GetSalesDetail("Quantity", "sum"),
            // monthlyProductSales = sales.GetMonthSalesDetail("Quantity", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            // totalRevenue = sales.GetSalesDetail("TotalSalesAmount", "sum"),
            // monthRevenue = sales.GetMonthSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            // totalProfit = sales.GetSalesDetail("GrossIncome", "sum"),
            // monthProfit = sales.GetMonthSalesDetail("GrossIncome", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),

            // FiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy-MM") + "-31'", 2024),
            // pastFiveMonthSales = sales.GetFiveMonthSales("TotalSalesAmount", "'" + DateTime.Now.AddYears(-1).ToString("yyyy") + "-01-01'", "'" + DateTime.Now.AddYears(-1).ToString("yyyy-MM") + "-31'", 2023),

            // branchSales = sales.GetBranchSalesSummary("TotalSalesAmount"),

            // dailySales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "cast(getdate() as Date)", "cast(getdate() as Date)"),
            // monthSales = sales.GetMonthSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("MMM") + "'", 2024),
            // yearSales = sales.GetDateWiseSalesDetail("TotalSalesAmount", "sum", "'" + DateTime.Now.ToString("yyyy") + "-01-01'", "'" + DateTime.Now.ToString("yyyy") + "-12-31'"),

            // BranchSales = sales.GetBranchSalesDetail("'" + DateTime.Now.ToString("MMM") + "'", 2024)
        };
        ViewBag.ProductDetail = ProductDashboardViewModel;
        return View();
    }


    public IActionResult ProductDetail()
    {
        return View();
    }

    public IActionResult CustomerDashboard()
    {
        Customer_Query customer = new Customer_Query();

        var Max = customer.GetQtyDetail("quantity", "Max");
        var Min = customer.GetQtyDetail("quantity", "Min");
        var Male = customer.GetCustomerTypes("gender", "Male");
        var Female = customer.GetCustomerTypes("gender", "Female");
        var totalCustomers = customer.GetCustomerCount("Email");
        var CustomerTypeName = customer.GetCustomerCount("CustomerTypeName");
        var Normal = customer.GetSumOfSale("TotalSalesAmount", "Normal");
        var Member = customer.GetSumOfSale("TotalSalesAmount", "Member");
        var MaxTax = customer.GetTax("Tax", "Max");
        var MinTax = customer.GetTax("Tax", "Min");
        var MaxTaxPaidUser = customer.GetCustomerNameWithMaxTax();
        var MinTaxPaidUser = customer.GetCustomerNameWithMinTax();
        var TotalTax = customer.GetSumOfTax("Tax");
        var topCustomers = customer.GetTop5CustomersByPurchaseDESC();

        // Bar Chart
        string fromDate = DateTime.Now.AddMonths(-5).ToString("yyyy-MM-01");
        string toDate = DateTime.Now.ToString("yyyy-MM-dd");
        int year = DateTime.Now.Year;

        var (maleSales, femaleSales) = customer.GetFiveMonthSalesByGender("TotalSalesAmount", fromDate, toDate, year);
        // Bar chart Data Dict
        var salesData = new Dictionary<string, decimal[]>
        {
            { "MaleSales", maleSales },
            { "FemaleSales", femaleSales }
        };


        // Tax Paid User Wise Dict
        var tax = new Dictionary<string, (string name, int Tax, string Title, string bg_color, string front_color)>
        {
            {"Max",(MaxTaxPaidUser, (int)MaxTax, "Max Tax Paid", "card statistics-card-1", "")},
            {"Min",(MinTaxPaidUser, (int)MinTax, "Min Tax Paid", "card statistics-card-1","")},
            {"Total",("All Customers", (int)TotalTax, "Total Tax Paid", "card statistics-card-1 bg-brand-color-1","text-white")},
        };

        // Top Boxes Dict
        var orderBoxes = new Dictionary<string, (string Icon, int Count, string Description, int DescriptionCount, string bg_color)>
        {
            { "Total Customers", ("users",(int)totalCustomers, "Unique Types", (int)CustomerTypeName, "card bg-grd-success order-card") },
            { "Male Purchasing",  ("users",   (int)Male, "Female Purchasing", (int)Female,  "card bg-grd-warning order-card") },
            { "Normal Type", ("dollar-sign", (int)Normal, "Member Type", (int)Member, "card bg-grd-primary order-card") },
            { "Max Qty Purchase",("shopping-bag",  (int)Max, "Min Qty Purchase", (int)Min, "card bg-grd-danger order-card") },

        };

        ViewData["TopCustomers"] = topCustomers;
        ViewData["OrderBoxes"] = orderBoxes;
        ViewData["Tax"] = tax;
        ViewData["MostPurchase"] = salesData;
        return View();
    }

    public IActionResult CustomerDetail()
    {
        Customer_Query customer = new Customer_Query();

        var leastCustomers = customer.GetTop5CustomersByPurchaseASC();
        var topCustomers = customer.GetTop5CustomersByPurchaseDESC();
        var CustomerDetails = customer.GetCustomersDetails();

        var dataDict = new Dictionary<string, (string title, List<CustomerBase> data)>()
        {
            { "LeastCustomers", ("Top 5 Customers with Least Purchasing", leastCustomers.Cast<CustomerBase>().ToList()) },
            { "TopCustomers", ("Top 5 Customers With Highest Purchasing", topCustomers.Cast<CustomerBase>().ToList()) },
            { "CustomerDetails", ("Customer Details", CustomerDetails.Cast<CustomerBase>().ToList()) },
        };

        ViewData["Customers"] = dataDict;
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
