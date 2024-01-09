using Models;

namespace DBBL.Services;

public interface IDBManager
{
    public Monster GetRandomMonsterFromDB();
}