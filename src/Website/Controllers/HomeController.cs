using System.Diagnostics;

using CrateSample.Application.Configuration;
using CrateSample.Application.Services.Configuration;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Website.Models;

namespace Website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SharedConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfigurationService configurationService)
    {
        _logger = logger;
        _configuration = configurationService.Shared();
    }

    public IActionResult Index()
    {
        return View(_configuration);
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
