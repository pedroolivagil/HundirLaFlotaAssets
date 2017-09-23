using MongoDB.Driver.Builders;

public class CityController{
    private _PersistenceManager pm;

    public CityController(){
        pm = new _PersistenceManager();
    }

    public City FindById(long id){
        var query = Query<City>.EQ(City => City.IdCity, id);
        return pm.FindByKey<City>(query);
    }

    public City FindByCode(string code){
        var query = Query<City>.EQ(City => City.Code, code.ToUpper());
        return pm.FindByKey<City>(query);
    }

    public bool Create(City city){
        if (FindByCode(city.Code) != null){
            return false;
        }
        city.IdCity = GenerateId();
        return pm.Persist<City>(city);
    }

    public bool Update(City city){
        return pm.Merge<City>(city);
    }

    public bool Delete(long id){
        var query = Query<City>.EQ(City => City.IdCity, id);
        return pm.Remove<City>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<City>(City => City.IdCity);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}