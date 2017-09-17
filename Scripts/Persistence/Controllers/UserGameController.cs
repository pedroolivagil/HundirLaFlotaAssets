using System.Text;
using MongoDB.Driver.Builders;

public class UserGameController{
    private _PersistenceManager pm;

    public UserGameController(){
        pm = new _PersistenceManager();
    }

    public User FindById(long id){
        var query = Query<User>.EQ(User => User.IdUser, id);
        return pm.FindByKey<User>(query);
    }

    public  FindByCode(string code){
        var query = Query<>.EQ( => .Code, code);
        return pm.FindByKey<>(query);
    }

    public bool Create(User user){
//        if (FindByUserName(user.Username) != null || FindByEmail(user.Email) != null){
//            return false;
//        }
        user.IdUser = GenerateId();
        user.AcountActive = false;
        user.Code = GenerateCode(user);
        user.Password = GameManager.CryptString(user.Password);
        return pm.Persist<User>(user);
    }

    public bool Update(User user){
        return pm.Merge<User>(user);
    }

    public bool Delete(long id){
        var query = Query<User>.EQ(User => User.IdUser, id);
        return pm.Remove<User>(query);
    }

    public string GenerateCode(User user){
        StringBuilder code = new StringBuilder();
        code.Append(user.Firstname.Substring(0, user.Firstname.Length < 5 ? user.Firstname.Length : 5));
        code.Append(user.Lastname.Substring(0, user.Lastname.Length < 5 ? user.Lastname.Length : 5));
        code.Append(GameManager.GetCurrentTimestamp());
        return code.ToString();
    }

    public User Clone(User user){
        User retorno = new User();
        retorno.FlagActive = user.FlagActive;
        retorno.EntryDate = user.EntryDate;
        retorno.Code = user.Code;
        retorno.Birthday = user.Birthday;
        retorno.AcountActive = user.AcountActive; // True si el usuario tiene el email verificado  
        retorno.Gender = user.Gender;
        retorno.TypeUser = user.TypeUser;
        retorno.Username = user.Username;
        retorno.Password = user.Password;
        retorno.Email = user.Email;
        retorno.Firstname = user.Firstname;
        retorno.Lastname = user.Lastname;
        retorno.EmailSecurity = user.EmailSecurity;
        retorno.Phone = user.Phone;
        retorno.Address = user.Address;
        retorno.Country = user.Country;
        retorno.State = user.State;
        return retorno;
    }

    private long GetLastId(){
        return pm.GetLastId<User>(User => User.IdUser);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}