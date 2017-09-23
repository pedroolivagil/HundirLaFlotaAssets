using MongoDB.Driver.Builders;

public class BattleController{
    private _PersistenceManager pm;

    public BattleController(){
        pm = new _PersistenceManager();
    }

    public Battle FindById(long id){
        var query = Query<Battle>.EQ(Battle => Battle.IdBattle, id);
        return pm.FindByKey<Battle>(query);
    }

    public Battle FindByCode(string code){
        var query = Query<Battle>.EQ(Battle => Battle.Code, code.ToUpper());
        return pm.FindByKey<Battle>(query);
    }

    public bool Create(Battle battle){
        if (FindByCode(battle.Code) != null){
            return false;
        }
        battle.IdBattle = GenerateId();
        return pm.Persist<Battle>(battle);
    }

    public bool Update(Battle battle){
        return pm.Merge<Battle>(battle);
    }

    public bool Delete(long id){
        var query = Query<Battle>.EQ(Battle => Battle.IdBattle, id);
        return pm.Remove<Battle>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Battle>(Battle => Battle.IdBattle);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}