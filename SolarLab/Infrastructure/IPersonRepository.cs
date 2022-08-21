using SolarLab.Models;

namespace SolarLab.Infrastructure;

public interface IPersonRepository
{
    IEnumerable<BirthdayPerson> GetFutureBirthdays();
    IEnumerable<BirthdayPerson> GetAllBirthdays();

    BirthdayPerson GetBirthdayById(int id);

    void AddBirthday(BirthdayPerson birthdayPerson);

    void EditBirthday(BirthdayPerson birthdayPerson);

    void DeleteBirthday(int id);
}

