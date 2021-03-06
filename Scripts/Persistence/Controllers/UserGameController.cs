﻿using System.Text;
using MongoDB.Driver.Builders;

public class UserGameController{
    private _PersistenceManager pm;

    public UserGameController(){
        pm = new _PersistenceManager();
    }

    public UserGame FindById(long id){
        var query = Query<UserGame>.EQ(UserGame => UserGame.IdUserGame, id);
        return pm.FindByKey<UserGame>(query);
    }

    public UserGame FindByCode(string code){
        var query = Query<UserGame>.EQ(UserGame => UserGame.Code, code.ToUpper());
        return pm.FindByKey<UserGame>(query);
    }

    public UserGame FindByIdUser(long idUser){
        var query = Query<UserGame>.EQ(UserGame => UserGame.User, idUser);
        return pm.FindByKey<UserGame>(query);
    }

    public bool Create(UserGame userGame){
        if (FindByCode(userGame.Code) != null){
            return false;
        }
        userGame.IdUserGame = GenerateId();
        userGame.Code = GenerateCode();
        return pm.Persist<UserGame>(userGame);
    }

    public bool Update(UserGame userGame){
        return pm.Merge<UserGame>(userGame);
    }

    public bool Delete(long id){
        var query = Query<UserGame>.EQ(UserGame => UserGame.IdUserGame, id);
        return pm.Remove<UserGame>(query);
    }

    public string GenerateCode(){
        StringBuilder code = new StringBuilder();
        code.Append(System.Guid.NewGuid());
        return code.ToString();
    }

    private long GetLastId(){
        return pm.GetLastId<UserGame>(UserGame => UserGame.IdUserGame);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}