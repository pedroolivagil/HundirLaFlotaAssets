using MongoDB.Driver.Builders;

public class WeaponController{
    private _PersistenceManager pm;

    public WeaponController(){
        pm = new _PersistenceManager();
    }

    public Weapon FindById(long id){
        var query = Query<Weapon>.EQ(Weapon => Weapon.IdWeapon, id);
        return pm.FindByKey<Weapon>(query);
    }

    public Weapon FindByCode(string code){
        var query = Query<Weapon>.EQ(Weapon => Weapon.Code, code.ToUpper());
        return pm.FindByKey<Weapon>(query);
    }

    public bool Create(Weapon weapon){
        if (FindByCode(weapon.Code) != null){
            return false;
        }
        weapon.IdWeapon = GenerateId();
        return pm.Persist<Weapon>(weapon);
    }

    public bool Update(Weapon weapon){
        return pm.Merge<Weapon>(weapon);
    }

    public bool Delete(long id){
        var query = Query<Weapon>.EQ(Weapon => Weapon.IdWeapon, id);
        return pm.Remove<Weapon>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Weapon>(Weapon => Weapon.IdWeapon);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}