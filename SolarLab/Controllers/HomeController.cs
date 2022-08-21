using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Infrastructure;
using SolarLab.Models;

namespace SolarLab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPersonRepository _personRepository;


    public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository)
    {
        _logger = logger;
        _personRepository = personRepository;
    }

    public IActionResult Index()
    {
        return View(_personRepository.GetFutureBirthdays());
    }

    public IActionResult AllBirthdays()
    {
        return View(_personRepository.GetAllBirthdays());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}