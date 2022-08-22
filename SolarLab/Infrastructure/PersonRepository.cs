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

    public BirthdayPerson GetBirthdayById(int id)
    {
        return _dbContext.BirthdayPersons.FirstOrDefault(x=>x.Id == id) ?? throw new KeyNotFoundException();
    }

    public void AddBirthday(BirthdayPerson birthdayPerson)
    {
        _dbContext.BirthdayPersons.Add(birthdayPerson);
        _dbContext.SaveChanges();
        
    }
    
    public void EditBirthday(BirthdayPerson birthdayPerson)
    {
        if (_dbContext.BirthdayPersons.FirstOrDefault(x=>x.Id == birthdayPerson.Id) == null) return;
        _dbContext.BirthdayPersons.Update(birthdayPerson);
        _dbContext.SaveChanges();
        
    }
    
    public void DeleteBirthday(int id)
    {
        _dbContext.BirthdayPersons.Remove(GetBirthdayById(id));
        _dbContext.SaveChanges();
        
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}