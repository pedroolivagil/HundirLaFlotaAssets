using System.Text;
using MongoDB.Driver.Builders;

public class ProfileAIController{
    private _PersistenceManager pm;

    public ProfileAIController(){
        pm = new _PersistenceManager();
    }

    public ProfileAI FindById(long id){
        var query = Query<ProfileAI>.EQ(ProfileAI => ProfileAI.IdProfileAi, id);
        return pm.FindByKey<ProfileAI>(query);
    }

    public ProfileAI FindByCode(string code){
        var query = Query<ProfileAI>.EQ(ProfileAI => ProfileAI.Code, code.ToUpper());
        return pm.FindByKey<ProfileAI>(query);
    }

    public bool Create(ProfileAI profileAi){
        if (FindByCode(profileAi.Code) != null){
            return false;
        }
        profileAi.IdProfileAi = GenerateId();
        profileAi.Code = GenerateCode();
        return pm.Persist<ProfileAI>(profileAi);
    }

    public bool Update(ProfileAI profileAi){
        return pm.Merge<ProfileAI>(profileAi);
    }

    public bool Delete(long id){
        var query = Query<ProfileAI>.EQ(ProfileAI => ProfileAI.IdProfileAi, id);
        return pm.Remove<ProfileAI>(query);
    }

    public string GenerateCode(){
        StringBuilder code = new StringBuilder();
        code.Append(System.Guid.NewGuid());
        code.Append(GameManager.GetCurrentTimestamp());
        return code.ToString();
    }

    private long GetLastId(){
        return pm.GetLastId<ProfileAI>(ProfileAI => ProfileAI.IdProfileAi);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}