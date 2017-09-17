using MongoDB.Driver.Builders;

public class AppLocaleController{
    private _PersistenceManager pm;

    public AppLocaleController(){
        pm = new _PersistenceManager();
    }

    public AppLocale FindById(long id){
        var query = Query<AppLocale>.EQ(AppLocale => AppLocale.IdAppLocale, id);
        return pm.FindByKey<AppLocale>(query);
    }

    public AppLocale FindByCodeISO(string code){
        var query = Query<AppLocale>.EQ(AppLocale => AppLocale.Code, code);
        return pm.FindByKey<AppLocale>(query);
    }

    public bool Create(AppLocale appLocale){
        if (FindByCodeISO(appLocale.Code) != null){
            return false;
        }
        appLocale.IdAppLocale = GenerateId();
        return pm.Persist<AppLocale>(appLocale);
    }

    public bool Update(AppLocale appLocale){
        return pm.Merge<AppLocale>(appLocale);
    }

    public bool Delete(long id){
        var query = Query<AppLocale>.EQ(AppLocale => AppLocale.IdAppLocale, id);
        return pm.Remove<AppLocale>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<AppLocale>(AppLocale => AppLocale.IdAppLocale);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}