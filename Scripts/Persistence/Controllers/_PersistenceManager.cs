using MongoDB.Driver;

public class _PersistenceManager{
    private DB _db;

    public _PersistenceManager(){
        _db = DB.GetInstance();
    }

    public virtual long Count<T>(){
        return _db.Count<T>();
    }

    public T FindById<T>(IMongoQuery query){
        return _db.FindOneById<T>(query);
    }
}