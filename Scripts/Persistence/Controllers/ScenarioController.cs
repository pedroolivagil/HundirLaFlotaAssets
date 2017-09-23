using MongoDB.Driver.Builders;

public class ScenarioController{
    private _PersistenceManager pm;

    public ScenarioController(){
        pm = new _PersistenceManager();
    }

    public Scenario FindById(long id){
        var query = Query<Scenario>.EQ(Scenario => Scenario.IdScenario, id);
        return pm.FindByKey<Scenario>(query);
    }

    public Scenario FindByCode(string code){
        var query = Query<Scenario>.EQ(Scenario => Scenario.Code, code.ToUpper());
        return pm.FindByKey<Scenario>(query);
    }

    public bool Create(Scenario scenario){
        if (FindByCode(scenario.Code) != null){
            return false;
        }
        scenario.IdScenario = GenerateId();
        return pm.Persist<Scenario>(scenario);
    }

    public bool Update(Scenario scenario){
        return pm.Merge<Scenario>(scenario);
    }

    public bool Delete(long id){
        var query = Query<Scenario>.EQ(Scenario => Scenario.IdScenario, id);
        return pm.Remove<Scenario>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Scenario>(Scenario => Scenario.IdScenario);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}