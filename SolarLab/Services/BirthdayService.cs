using SolarLab.Infrastructure;
using SolarLab.Models;

namespace SolarLab.Services;

public class BirthdayService
{
    private readonly IPersonRepository _personRepository;
    private readonly IWebHostEnvironment _environment;

    public BirthdayService(IPersonRepository personRepository, IWebHostEnvironment environment)
    {
        _personRepository = personRepository;
        _environment = environment;
    }

    public async Task AddBirthday(AddBirthdayPersonViewModel birthdayPerson)
    {

        if (birthdayPerson.PhotoLink != null)
        {
            // путь к папке Files
            string path = "/img/" + birthdayPerson.PhotoLink.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await birthdayPerson.PhotoLink.CopyToAsync(fileStream);
            }
        }
        
        _personRepository.AddBirthday(new BirthdayPerson
        {
            BirthDate = birthdayPerson.BirthDate,
            Name = birthdayPerson.Name,
            Surname = birthdayPerson.Surname,
            Lastname = birthdayPerson.Lastname,
            PhotoLink = birthdayPerson.PhotoLink?.FileName ?? "default.jpg"
        });
    }

    public void DeleteBirthday(int id)
    {
        _personRepository.DeleteBirthday(id);
    }

    public async Task EditBirthday(EditBirthdayPersonViewModel editBirthdayPersonViewModel)
    {
        if (editBirthdayPersonViewModel.PhotoLink != null)
        {
            // путь к папке Files
            string path = "/img/" + editBirthdayPersonViewModel.PhotoLink.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await editBirthdayPersonViewModel.PhotoLink.CopyToAsync(fileStream);
            }
        }

        var birthday = _personRepository.GetBirthdayById(editBirthdayPersonViewModel.Id);
        if (birthday == null) return;
        birthday.Name = editBirthdayPersonViewModel.Name;
        birthday.PhotoLink = editBirthdayPersonViewModel.PhotoLink?.FileName ?? "default.jpg";
        birthday.Surname = editBirthdayPersonViewModel.Surname;
        birthday.Lastname = editBirthdayPersonViewModel.Lastname;
        birthday.BirthDate = editBirthdayPersonViewModel.BirthDate;
        
        _personRepository.SaveChanges();
    }
}

// public int Id { get; set; }
// public DateTime BirthDate { get; set; }
// public string? PhotoLink { get; set; }
// public string Name { get; set; }
// public string Surname { get; set; }
// public string Lastname { get; set; }