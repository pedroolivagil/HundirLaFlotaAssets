using MongoDB.Driver.Builders;

public class HarborController{
    private _PersistenceManager pm;

    public HarborController(){
        pm = new _PersistenceManager();
    }

    public Harbor FindById(long id){
        var query = Query<Harbor>.EQ(Harbor => Harbor.IdHarbor, id);
        return pm.FindByKey<Harbor>(query);
    }

    public Harbor FindByCode(string code){
        var query = Query<Harbor>.EQ(Harbor => Harbor.Code, code.ToUpper());
        return pm.FindByKey<Harbor>(query);
    }

    public bool Create(Harbor harbor){
        if (FindByCode(harbor.Code) != null){
            return false;
        }
        harbor.IdHarbor = GenerateId();
        return pm.Persist<Harbor>(harbor);
    }

    public bool Update(Harbor harbor){
        return pm.Merge<Harbor>(harbor);
    }

    public bool Delete(long id){
        var query = Query<Harbor>.EQ(Harbor => Harbor.IdHarbor, id);
        return pm.Remove<Harbor>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Harbor>(Harbor => Harbor.IdHarbor);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}