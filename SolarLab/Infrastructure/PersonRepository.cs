using SolarLab.Models;

namespace SolarLab.Infrastructure;

public class PersonRepository : IPersonRepository
{
    private readonly MyDbContext _dbContext;

    public PersonRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<BirthdayPerson> GetFutureBirthdays()
    {
        return _dbContext.BirthdayPersons.Where(x => x.BirthDate.DayOfYear >= DateTime.Now.DayOfYear 
                                                     && x.BirthDate.DayOfYear < DateTime.Now.DayOfYear + 31).ToList();
    }

    public IEnumerable<BirthdayPerson> GetAllBirthdays()
    {
        return _dbContext.BirthdayPersons.ToList();
    }
}