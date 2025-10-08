using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrateSample.Application.Configuration;
using CrateSample.Application.Services.Configuration;
using CrateSample.Application.Services.CustomerOrders;
using Website.Models;
using CrateSample.Application.Dto;

namespace Website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerOrderService _customerOrderService;
    private readonly SharedConfiguration _configuration;

    public HomeController(
        ILogger<HomeController> logger,
        IConfigurationService configurationService,
        ICustomerOrderService customerOrderService)
    {
        _logger = logger;
        _customerOrderService = customerOrderService;
        _configuration = configurationService.Shared();
    }

    public IActionResult Index()
    {
        IReadOnlyCollection<OrderListing> empty = Array.Empty<OrderListing>();
        return View(empty);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var model = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(model);
    }
}
