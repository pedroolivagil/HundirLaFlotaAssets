using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

public class _PersistenceManager{
    private DB _db;

    public _PersistenceManager(){
        _db = DB.GetInstance();
    }

    public long Count<T>(){
        return _db.Count<T>();
    }

    public long CountByKey<T>(IMongoQuery query){
        return _db.Count<T>(query);
    }

    public List<T> FindAll<T>(){
        return _db.FindAll<T>();
    }

    public List<T> FindAllByKey<T>(IMongoQuery query){
        return _db.FindAllByKey<T>(query);
    }

    public T FindByKey<T>(IMongoQuery query){
        return _db.FindOneByKey<T>(query);
    }

    public long GetLastId<T>(Expression<Func<T, long>> expression){
        return _db.GetLastId(expression);
    }

    public bool Merge<T>(_Entity entity){
        entity.Code = entity.Code.ToUpper();
        return _db.Merge<T>(entity);
    }

    public bool Persist<T>(_Entity entity){
        entity.Code = entity.Code.ToUpper();
        entity.EntryDate = GameManager.GetCurrentTimestamp();
        entity.FlagActive = true;
        return _db.Persist<T>(entity);
    }

    public bool Remove<T>(IMongoQuery query){
        return _db.Remove<T>(query);
    }
}