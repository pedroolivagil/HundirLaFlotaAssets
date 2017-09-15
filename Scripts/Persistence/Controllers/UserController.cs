using MongoDB.Driver.Builders;

public class UserController{
    private _PersistenceManager pm;

    public UserController(){
        pm = new _PersistenceManager();
    }

    public User FindById(long id){
        var query = Query<User>.EQ(User => User.id_user, id);
        return pm.FindById<User>(query);
    }
}