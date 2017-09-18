using MongoDB.Driver.Builders;

public class VesselController{
    private _PersistenceManager pm;

    public VesselController(){
        pm = new _PersistenceManager();
    }

    public Vessel FindById(long id){
        var query = Query<Vessel>.EQ(Vessel => Vessel.IdVessel, id);
        return pm.FindByKey<Vessel>(query);
    }

    public Vessel FindByCode(string code){
        var query = Query<Vessel>.EQ(Vessel => Vessel.Code, code);
        return pm.FindByKey<Vessel>(query);
    }

    public bool Create(Vessel vessel){
        if (FindByCode(vessel.Code) != null){
            return false;
        }
        vessel.IdVessel = GenerateId();
        return pm.Persist<Vessel>(vessel);
    }

    public bool Update(Vessel vessel){
        return pm.Merge<Vessel>(vessel);
    }

    public bool Delete(long id){
        var query = Query<Vessel>.EQ(Vessel => Vessel.IdVessel, id);
        return pm.Remove<Vessel>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Vessel>(Vessel => Vessel.IdVessel);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}