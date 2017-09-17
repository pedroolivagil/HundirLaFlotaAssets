using MongoDB.Bson;

public class UserGame : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdUserGame{ get; set; }
    public int User{ get; set; }
    public int Scenario{ get; set; }
    public int Bank{ get; set; }
    public int PlayTime{ get; set; }
}