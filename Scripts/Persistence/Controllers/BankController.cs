using System.Text;
using MongoDB.Driver.Builders;

public class BankController{
    private _PersistenceManager pm;

    public BankController(){
        pm = new _PersistenceManager();
    }

    public Bank FindById(long id){
        var query = Query<Bank>.EQ(Bank => Bank.IdBank, id);
        return pm.FindByKey<Bank>(query);
    }

    public Bank FindByCode(string code){
        var query = Query<Bank>.EQ(Bank => Bank.Code, code);
        return pm.FindByKey<Bank>(query);
    }

    public bool Create(Bank bank){
        if (FindByCode(bank.Code) != null){
            return false;
        }
        bank.IdBank = GenerateId();
        bank.Code = GenerateCode();
        return pm.Persist<Bank>(bank);
    }

    public bool Update(Bank bank){
        return pm.Merge<Bank>(bank);
    }

    public bool Delete(long id){
        var query = Query<Bank>.EQ(Bank => Bank.IdBank, id);
        return pm.Remove<Bank>(query);
    }

    public string GenerateCode(){
        StringBuilder code = new StringBuilder();
        code.Append(System.Guid.NewGuid());
        return code.ToString();
    }


    private long GetLastId(){
        return pm.GetLastId<Bank>(Bank => Bank.IdBank);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}