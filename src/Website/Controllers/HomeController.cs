using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrateSample.Application.Configuration;
using CrateSample.Application.ServiceAgents.Orders;
using CrateSample.Application.Services.Configuration;
using CrateSample.Application.Services.CustomerOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    public async Task<IActionResult> Index([FromQuery] string? ids)
    {
        IEnumerable<Guid>? profileIds = null;
        var errors = new List<string>();

        if (!string.IsNullOrWhiteSpace(ids))
        {
            var tokens = ids.Split(new[] { ',', ';', ' ', '\r', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var unique = new HashSet<Guid>();

            foreach (var token in tokens)
            {
                if (Guid.TryParse(token, out var guid))
                    unique.Add(guid);
                else
                    errors.Add($"Invalid GUID: {token}");
            }

            if (errors.Count > 0)
                _logger.LogWarning("ProfileId parse errors: {Errors}", string.Join(", ", errors));

            profileIds = unique.ToList();
        }

        var customerOrders = await _customerOrderService.GetOrderListings(profileIds);

        ViewBag.Errors = errors;

        return View(customerOrders);
    }

    [HttpGet("/home/order/{orderId}")]
    public async Task<IActionResult> OrderDetails(string orderId)
    {
        var details = await _customerOrderService.GetOrderDetails(orderId);

        if (details is null || details.Count == 0)
            return NotFound();

        return View(details);
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
