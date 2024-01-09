using Models;

namespace DBBL.Services;

public class Battle : IBattle
{
    public BattleResult GetResult(Player player, Monster monster)
    {
        var result = new BattleResult
        {
            Logs = new List<Log>()
        };
        while (player.HitPoints > 0 && monster.HitPoints > 0)
        {
            if (player.HitPoints > 0)
            {
                var log = ProcessRound(player, monster);
                log.CharacterName = player.Name;
                log.EnemyName = monster.Name;
                result.Logs.Add(log);
            }

            if (monster.HitPoints > 0)
            {
                var log = ProcessRound(monster, player);
                log.CharacterName = monster.Name;
                log.EnemyName = player.Name;
                result.Logs.Add(log);
            }
        }

        result.Winner = player.HitPoints > 0 ? player.Name : monster.Name;
        return result;
    }
    
    private Log ProcessRound(Entity active, Entity passive)
    {
        var log = new Log();
        var rnd = new Random();
        var throws = int.Parse(active.Damage.Split('d')[0]);
        var dice = int.Parse(active.Damage.Split('d')[1]);
        log.HitType = new HitType[active.AttackPerRound];
        log.Damage = new int[active.AttackPerRound];
        log.EnemyHp = new int[active.AttackPerRound];
        log.DiceRoll = new int[active.AttackPerRound];
        log.AttackModifier = active.AttackModifier;
        for (var i = 0; i < active.AttackPerRound && passive.HitPoints > 0; i++)
        {
            var hitRoll = rnd.Next(1, 21);
            log.DiceRoll[i] = hitRoll;
            log.EnemyHp[i] = passive.HitPoints;
            if (hitRoll == 1 || log.DiceRoll[i] < passive.ArmorClass)
            {
                log.HitType[i] = HitType.Miss;
                continue;
            }

            if (hitRoll == 20)
                log.HitType[i] = HitType.Critical;
            else log.HitType[i] = HitType.Hit;
            for (var _ = 0; _ < throws; _++)
                log.Damage[i] += (rnd.Next(1, dice + 1) + active.DamageModifier) * hitRoll / 10;
            passive.HitPoints -= Math.Min(passive.HitPoints, log.Damage[i]);
            log.EnemyHp[i] = passive.HitPoints;
            if (passive.HitPoints == 0) break;
        }
        return log;
    }
}