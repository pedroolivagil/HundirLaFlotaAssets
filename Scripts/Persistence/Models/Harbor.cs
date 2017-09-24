using MongoDB.Bson;

public class Harbor : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdHarbor{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public double PriceGoldRepair{ get; set; } //units
    public int PriceGemsRepair{ get; set; } //units
    public int TimeGoldRepair{ get; set; } //in seconds
    public int TimeGemsRepair{ get; set; } //in seconds
}