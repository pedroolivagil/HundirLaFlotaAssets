using System.Text;
using MongoDB.Driver.Builders;

public class MarketController{
    private _PersistenceManager pm;

    public MarketController(){
        pm = new _PersistenceManager();
    }

    public Market FindById(long id){
        var query = Query<Market>.EQ(Market => Market.IdMarket, id);
        return pm.FindByKey<Market>(query);
    }

    public Market FindByCode(string code){
        var query = Query<Market>.EQ(Market => Market.Code, code.ToUpper());
        return pm.FindByKey<Market>(query);
    }

    public bool Create(Market market){
        if (FindByCode(market.Code) != null){
            return false;
        }
        market.IdMarket = GenerateId();
        market.Code = GenerateCode();
        return pm.Persist<Market>(market);
    }

    public bool Update(Market market){
        return pm.Merge<Market>(market);
    }

    public bool Delete(long id){
        var query = Query<Market>.EQ(Market => Market.IdMarket, id);
        return pm.Remove<Market>(query);
    }

    public string GenerateCode(){
        StringBuilder code = new StringBuilder();
        code.Append(System.Guid.NewGuid());
        code.Append(GameManager.GetCurrentTimestamp());
        return code.ToString();
    }

    private long GetLastId(){
        return pm.GetLastId<Market>(Market => Market.IdMarket);
    }

    private long GenerateId(){
        return GetLastId() + GameManager.RandomBetween();
    }
}