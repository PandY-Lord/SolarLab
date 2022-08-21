using SolarLab.Models;

namespace SolarLab.Infrastructure;

public interface IPersonRepository
{
    IEnumerable<BirthdayPerson> GetFutureBirthdays();
    IEnumerable<BirthdayPerson> GetAllBirthdays();
}
