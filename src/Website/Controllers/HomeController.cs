using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using CrateSample.Application.Configuration;
using CrateSample.Application.ServiceAgents.Orders;
using CrateSample.Application.Services.Configuration;
using CrateSample.Application.Services.CustomerOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Website.Models;

namespace Website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerOrderService _customerOrderService;
    private readonly SharedConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfigurationService configurationService, ICustomerOrderService customerOrderService)
    {
        _logger = logger;
        _customerOrderService = customerOrderService;
        _configuration = configurationService.Shared();
    }

    public async Task<IActionResult> Index()
    {
        var customerOrders = await _customerOrderService.GetOrderListings();

        return View(customerOrders);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var model =
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

        return View(model);
    }
}