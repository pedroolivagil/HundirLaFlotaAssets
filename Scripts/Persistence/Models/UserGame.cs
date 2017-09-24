using MongoDB.Bson;

public class UserGame : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdUserGame{ get; set; }
    public long User{ get; set; }
    public int Scenario{ get; set; }
    public long Bank{ get; set; }
    public int PlayTime{ get; set; }
}