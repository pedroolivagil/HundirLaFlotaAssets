using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using UnityEngine;

public class DB{
    private static string DB_HOST = "192.168.1.34";
    private static string DB_USER = "admin";
    private static string DB_PASSWORD = "oreo_20081991_Aa";
    private static string DB_DB = "hundirFlota";
    private static string DB_PORT = "27018";

    private static DB _instance;
    private GameObject _dialogConnection;

    private MongoClient Client{ get; set; }
    private MongoServer Server{ get; set; }
    private MongoDatabase _db;

    public static readonly string URI_MONGO = "mongodb://" + DB_HOST + ":" + DB_PORT;

    public static DB GetInstance(){
        Init();
        return _instance;
    }

    private static void Init(){
        if (_instance == null){
            _instance = new DB();
            _instance.Client = new MongoClient(URI_MONGO);
            _instance.Server = _instance.Client.GetServer();
            _instance._db = _instance.Server.GetDatabase(DB_DB);
        }
    }

    public long Count<T>(){
        Debug.Log("Count in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.Count();
    }

    public long Count<T>(IMongoQuery query){
        Debug.Log("Count in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.Count(query);
    }

    public List<T> FindAll<T>(){
        Debug.Log("FindAll in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.FindAll().ToList();
    }

    public List<T> FindAllByKey<T>(IMongoQuery query){
        Debug.Log("FindAllByKey in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.Find(query).ToList();
    }

    public T FindOneByKey<T>(IMongoQuery query){
        Debug.Log("FindOneByKey in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.FindOne(query);
    }

    public bool Persist<T>(_Entity entity){
        Debug.Log("Persist in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        var retorno = collection.Insert(entity);
        return retorno.Ok;
    }

    public bool Merge<T>(_Entity entity){
        Debug.Log("Merge in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        var retorno = collection.Save(entity);
        return retorno.Ok;
    }

    public bool Remove<T>(IMongoQuery query){
        Debug.Log("Remove in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        var retorno = collection.Remove(query);
        return retorno.Ok;
    }

    public long GetLastId<T>(Expression<Func<T, long>> expression){
        Debug.Log("GetLastId in collection: " + typeof(T));
        MongoCollection<T> collection = _instance._db.GetCollection<T>(typeof(T).ToString());
        return collection.AsQueryable().Max(expression);
    }
}