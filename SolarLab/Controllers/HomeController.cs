using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Infrastructure;
using SolarLab.Models;
using SolarLab.Services;

namespace SolarLab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPersonRepository _personRepository;
    private readonly BirthdayService _birthdayService;


    public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository, BirthdayService birthdayService)
    {
        _logger = logger;
        _personRepository = personRepository;
        _birthdayService = birthdayService;
    }

    public IActionResult Index()
    {
        return View(_personRepository.GetFutureBirthdays());
    }

    public IActionResult AllBirthdays()
    {
        return View(_personRepository.GetAllBirthdays());
    }

    public IActionResult AddBirthday()
    {
        return View("AddEditBirthday", new BirthdayPerson());
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBirthdayPost(AddBirthdayPersonViewModel birthdayPerson)
    {
        await _birthdayService.AddBirthday(birthdayPerson);
        return RedirectToAction("AllBirthdays");
    }
    
    [HttpGet]
    public IActionResult DeleteBirthday( int id)
    {
        _birthdayService.DeleteBirthday(id);
        return RedirectToAction("AllBirthdays");
    }
    
    [HttpGet]
    public IActionResult EditBirthday(int id)
    {
        var birthday = _personRepository.GetBirthdayById(id);
        return View("AddEditBirthday", birthday);
        
    }
    
    [HttpPost]
    public async Task<IActionResult> EditBirthdayPost(EditBirthdayPersonViewModel editBirthdayPersonViewModel)
    {
        await _birthdayService.EditBirthday(editBirthdayPersonViewModel);
        return RedirectToAction("AllBirthdays");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}