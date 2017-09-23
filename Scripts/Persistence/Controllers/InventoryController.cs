using System.Text;
using MongoDB.Driver.Builders;

public class InventoryController{
    private _PersistenceManager pm;

    public InventoryController(){
        pm = new _PersistenceManager();
    }

    public Inventory FindById(long id){
        var query = Query<Inventory>.EQ(Inventory => Inventory.IdInventory, id);
        return pm.FindByKey<Inventory>(query);
    }

    public Inventory FindByCode(string code){
        var query = Query<Inventory>.EQ(Inventory => Inventory.Code, code.ToUpper());
        return pm.FindByKey<Inventory>(query);
    }

    public bool Create(Inventory inventory){
        if (FindByCode(inventory.Code) != null){
            return false;
        }
        inventory.IdInventory = GenerateId();
        inventory.Code = GenerateCode();
        return pm.Persist<Inventory>(inventory);
    }

    public bool Update(Inventory inventory){
        return pm.Merge<Inventory>(inventory);
    }

    public bool Delete(long id){
        var query = Query<Inventory>.EQ(Inventory => Inventory.IdInventory, id);
        return pm.Remove<Inventory>(query);
    }

    public string GenerateCode(){
        StringBuilder code = new StringBuilder();
        code.Append(System.Guid.NewGuid());
        code.Append(GameManager.GetCurrentTimestamp());
        return code.ToString();
    }

    private long GetLastId(){
        return pm.GetLastId<Inventory>(Inventory => Inventory.IdInventory);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}