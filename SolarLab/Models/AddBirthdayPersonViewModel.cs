namespace SolarLab.Models;

public class AddBirthdayPersonViewModel
{
    public DateTime BirthDate { get; set; }
    public IFormFile PhotoLink { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Lastname { get; set; }
}