using MongoDB.Driver.Builders;

public class QuestController{
    private _PersistenceManager pm;

    public QuestController(){
        pm = new _PersistenceManager();
    }

    public Quest FindById(long id){
        var query = Query<Quest>.EQ(Quest => Quest.IdQuest, id);
        return pm.FindByKey<Quest>(query);
    }

    public Quest FindByCode(string code){
        var query = Query<Quest>.EQ(Quest => Quest.Code, code.ToUpper());
        return pm.FindByKey<Quest>(query);
    }

    public bool Create(Quest quest){
        if (FindByCode(quest.Code) != null){
            return false;
        }
        quest.IdQuest = GenerateId();
        return pm.Persist<Quest>(quest);
    }

    public bool Update(Quest quest){
        return pm.Merge<Quest>(quest);
    }

    public bool Delete(long id){
        var query = Query<Quest>.EQ(Quest => Quest.IdQuest, id);
        return pm.Remove<Quest>(query);
    }

    private long GetLastId(){
        return pm.GetLastId<Quest>(Quest => Quest.IdQuest);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}