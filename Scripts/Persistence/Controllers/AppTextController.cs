using MongoDB.Driver.Builders;

public class AppTextController{
    private _PersistenceManager pm;

    public AppTextController(){
        pm = new _PersistenceManager();
    }

    public AppText FindById(long id){
        var query = Query<AppText>.EQ(AppText => AppText.IdAppText, id);
        return pm.FindByKey<AppText>(query);
    }

    public AppLocale FindByCode(string code){
        var query = Query<AppLocale>.EQ(AppLocale => AppLocale.Code, code);
        return pm.FindByKey<AppLocale>(query);
    }

    public bool Create(AppText appText){
        if (FindByCode(appText.Code) != null){
            return false;
        }
        appText.IdAppText = GenerateId();
        return pm.Persist<AppText>(appText);
    }

    public bool Update(AppText appText){
        return pm.Merge<AppText>(appText);
    }

    public bool Delete(long id){
        var query = Query<AppText>.EQ(AppText => AppText.IdAppText, id);
        return pm.Remove<AppText>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<AppText>(AppText => AppText.IdAppText);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}