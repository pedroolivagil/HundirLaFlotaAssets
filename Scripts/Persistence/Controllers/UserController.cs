using System.Text;
using MongoDB.Driver.Builders;

public class UserController{
    private _PersistenceManager pm;

    public UserController(){
        pm = new _PersistenceManager();
    }

    public User FindById(long id){
        var query = Query<User>.EQ(User => User.IdUser, id);
        return pm.FindByKey<User>(query);
    }

    public User FindByUserName(string username){
        var query = Query<User>.EQ(User => User.Username, username);
        return pm.FindByKey<User>(query);
    }

    public User FindByEmail(string email){
        var query = Query<User>.EQ(User => User.Email, email);
        return pm.FindByKey<User>(query);
    }

    public bool Create(User user){
        if (FindByUserName(user.Username) != null || FindByEmail(user.Email) != null){
            return false;
        }
        user.IdUser = pm.Count<User>() + 1;
        user.AcountActive = false;
        user.Code = GenerateCode(user);
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
}