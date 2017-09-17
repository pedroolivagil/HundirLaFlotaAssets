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
        bank.Code = GenerateCode(bank);
        return pm.Persist<Bank>(bank);
    }

    public bool Update(Bank bank){
        return pm.Merge<Bank>(bank);
    }

    public bool Delete(long id){
        var query = Query<Bank>.EQ(Bank => Bank.IdBank, id);
        return pm.Remove<Bank>(query);
    }

    public string GenerateCode(Bank bank){
        StringBuilder code = new StringBuilder();
        code.Append(bank.Firstname.Substring(0, bank.Firstname.Length < 5 ? bank.Firstname.Length : 5));
        code.Append(bank.Lastname.Substring(0, bank.Lastname.Length < 5 ? bank.Lastname.Length : 5));
        code.Append(GameManager.GetCurrentTimestamp());
        return code.ToString();
    }

    public Bank Clone(Bank bank){
        Bank retorno = new Bank();
        retorno.FlagActive = bank.FlagActive;
        retorno.EntryDate = bank.EntryDate;
        retorno.Code = bank.Code;
        retorno.Birthday = bank.Birthday;
        retorno.AcountActive = bank.AcountActive; // True si el usuario tiene el email verificado  
        retorno.Gender = bank.Gender;
        retorno.TypeBank = bank.TypeBank;
        retorno.Bankname = bank.Bankname;
        retorno.Password = bank.Password;
        retorno.Email = bank.Email;
        retorno.Firstname = bank.Firstname;
        retorno.Lastname = bank.Lastname;
        retorno.EmailSecurity = bank.EmailSecurity;
        retorno.Phone = bank.Phone;
        retorno.Address = bank.Address;
        retorno.Country = bank.Country;
        retorno.State = bank.State;
        return retorno;
    }

    private long GetLastId(){
        return pm.GetLastId<Bank>(Bank => Bank.IdBank);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}