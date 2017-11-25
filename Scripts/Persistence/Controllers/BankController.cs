using System;
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
        var query = Query<Bank>.EQ(Bank => Bank.Code, code.ToUpper());
        return pm.FindByKey<Bank>(query);
    }

    public bool Create(Bank bank){
        if (FindByCode(bank.Code) != null){
            return false;
        }
        bank.IdBank = GenerateId();
        return pm.Persist<Bank>(bank);
    }

    public bool Update(Bank bank){
        return pm.Merge<Bank>(bank);
    }

    public bool Delete(long id){
        var query = Query<Bank>.EQ(Bank => Bank.IdBank, id);
        return pm.Remove<Bank>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Bank>(Bank => Bank.IdBank);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }

    public string GenerateAcountNumber(AppLocale locale){
        StringBuilder number = new StringBuilder();
        number.Append(locale.Code);
        number.Append(GameManager.FillStringWithChar(GameManager.RandomBetween(0, 99), "0", 2));
        number.Append(GameManager.FillStringWithChar(GameManager.RandomBetween(0, 999999), "0", 6));
        number.Append(GameManager.FillStringWithChar(GameManager.RandomBetween(0, 99999999), "0", 8));
        if (FindByCode(number.ToString()) != null){
            GenerateAcountNumber(locale);
        }
        return number.ToString();
    }
}