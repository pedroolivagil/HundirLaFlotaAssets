using MongoDB.Driver.Builders;

public class PowerupController{
    private _PersistenceManager pm;

    public PowerupController(){
        pm = new _PersistenceManager();
    }

    public Powerup FindById(long id){
        var query = Query<Powerup>.EQ(Powerup => Powerup.IdPowerup, id);
        return pm.FindByKey<Powerup>(query);
    }

    public Powerup FindByCode(string code){
        var query = Query<Powerup>.EQ(Powerup => Powerup.Code, code);
        return pm.FindByKey<Powerup>(query);
    }

    public bool Create(Powerup powerup){
        if (FindByCode(powerup.Code) != null){
            return false;
        }
        powerup.IdPowerup = GenerateId();
        return pm.Persist<Powerup>(powerup);
    }

    public bool Update(Powerup powerup){
        return pm.Merge<Powerup>(powerup);
    }

    public bool Delete(long id){
        var query = Query<Powerup>.EQ(Powerup => Powerup.IdPowerup, id);
        return pm.Remove<Powerup>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Powerup>(Powerup => Powerup.IdPowerup);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}