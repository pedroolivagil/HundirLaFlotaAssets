using MongoDB.Driver.Builders;

public class ItemController{
    private _PersistenceManager pm;

    public ItemController(){
        pm = new _PersistenceManager();
    }

    public Item FindById(long id){
        var query = Query<Item>.EQ(Item => Item.IdItem, id);
        return pm.FindByKey<Item>(query);
    }

    public Item FindByCode(string code){
        var query = Query<Item>.EQ(Item => Item.Code, code);
        return pm.FindByKey<Item>(query);
    }

    public bool Create(Item item){
        if (FindByCode(item.Code) != null){
            return false;
        }
        item.IdItem = GenerateId();
        return pm.Persist<Item>(item);
    }

    public bool Update(Item item){
        return pm.Merge<Item>(item);
    }

    public bool Delete(long id){
        var query = Query<Item>.EQ(Item => Item.IdItem, id);
        return pm.Remove<Item>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Item>(Item => Item.IdItem);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}