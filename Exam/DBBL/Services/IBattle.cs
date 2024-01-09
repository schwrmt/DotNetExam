using Models;

namespace DBBL.Services;

public interface IBattle
{
    public BattleResult GetResult(Player player, Monster monster);
}