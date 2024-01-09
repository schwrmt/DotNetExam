using System.Data.Common;
using Models;

namespace DBBL.Services;

public class DBManager : IDBManager
{
    private readonly ApplicationDbContext _dbContext;
    public DBManager(ApplicationDbContext db) => _dbContext = db;
    public Monster GetRandomMonsterFromDB()
    {
        var total = _dbContext.Monsters.Count();
        var rnd = new Random();
        var index = rnd.Next(total);
        return _dbContext.Monsters.ElementAt(index);
    }
}