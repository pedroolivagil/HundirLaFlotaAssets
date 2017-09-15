using MongoDB.Driver;
using MongoDB.Driver.Builders;
using UnityEngine;

public class DB : MonoBehaviour{
    private static string DB_HOST = "192.168.1.34";
    private static string DB_USER = "admin";
    private static string DB_PASSWORD = "oreo_20081991_Aa";
    private static string DB_DB = "hundirFlota";
    private static string DB_PORT = "27018";

    private static DB _instance;
    private GameObject _dialogConnection;

    private MongoClient Client{ get; set; }
    private MongoServer _server{ get; set; }
    private MongoDatabase db;

    public static readonly string URI_MONGO = "mongodb://" + DB_HOST + ":" + DB_PORT;

    public static DB GetInstance(){
        Init();
        return _instance;
    }

    private static void Init(){
        if (_instance == null){
            _instance = new DB();
            _instance.Client = new MongoClient(URI_MONGO);
            _instance._server = _instance.Client.GetServer();
            _instance.db = _instance._server.GetDatabase(DB_DB);
            foreach (string name in _instance.db.GetCollectionNames()){
                Debug.Log("Collection: " + name);
            }
        }
    }

    public long Count<T>(){
        Debug.Log("Count in collection: " + typeof(T));
        MongoCollection<T> collection = _instance.db.GetCollection<T>(typeof(T).ToString());
        return collection.Count();
    }

    public T FindOneById<T>(IMongoQuery query){
        Debug.Log("FindOneById in collection: " + typeof(T));
        MongoCollection<T> collection = _instance.db.GetCollection<T>(typeof(T).ToString());
        return collection.FindOne(query);
    }
}