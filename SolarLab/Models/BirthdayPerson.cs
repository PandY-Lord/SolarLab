namespace SolarLab.Models;
//Добавил описание сущности персоны
public class BirthdayPerson
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhotoLink { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Lastname { get; set; }
}