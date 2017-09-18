using MongoDB.Driver.Builders;

public class ResourceController{
    private _PersistenceManager pm;

    public ResourceController(){
        pm = new _PersistenceManager();
    }

    public Resource FindById(long id){
        var query = Query<Resource>.EQ(Resource => Resource.IdResource, id);
        return pm.FindByKey<Resource>(query);
    }

    public Resource FindByCode(string code){
        var query = Query<Resource>.EQ(Resource => Resource.Code, code);
        return pm.FindByKey<Resource>(query);
    }

    public bool Create(Resource resource){
        if (FindByCode(resource.Code) != null){
            return false;
        }
        resource.IdResource = GenerateId();
        return pm.Persist<Resource>(resource);
    }

    public bool Update(Resource resource){
        return pm.Merge<Resource>(resource);
    }

    public bool Delete(long id){
        var query = Query<Resource>.EQ(Resource => Resource.IdResource, id);
        return pm.Remove<Resource>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Resource>(Resource => Resource.IdResource);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}