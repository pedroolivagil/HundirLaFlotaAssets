using MongoDB.Driver.Builders;

public class RewardController{
    private _PersistenceManager pm;

    public RewardController(){
        pm = new _PersistenceManager();
    }

    public Reward FindById(long id){
        var query = Query<Reward>.EQ(Reward => Reward.IdReward, id);
        return pm.FindByKey<Reward>(query);
    }

    public Reward FindByCode(string code){
        var query = Query<Reward>.EQ(Reward => Reward.Code, code.ToUpper());
        return pm.FindByKey<Reward>(query);
    }

    public bool Create(Reward reward){
        if (FindByCode(reward.Code) != null){
            return false;
        }
        reward.IdReward = GenerateId();
        return pm.Persist<Reward>(reward);
    }

    public bool Update(Reward reward){
        return pm.Merge<Reward>(reward);
    }

    public bool Delete(long id){
        var query = Query<Reward>.EQ(Reward => Reward.IdReward, id);
        return pm.Remove<Reward>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Reward>(Reward => Reward.IdReward);
    }

    private int GenerateId(){
        return (int) GetLastId() + GameManager.RandomBetween();
    }
}