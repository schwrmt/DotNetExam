using DBBL.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DBBL.Controllers;

[ApiController]
public class BattleControler
{
    private readonly IDBManager DbManager;
    private readonly IBattle Battle;

    public BattleControler(IDBManager db, IBattle battle)
    {
        DbManager = db;
        Battle = battle;
    }

    [HttpPost]
    [Route("Fight")]
    public JsonResult Fight([FromBody] Player player)
    {
        return new JsonResult(Battle.GetResult(player, DbManager.GetRandomMonsterFromDB()));
    }

    
}