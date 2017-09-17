using MongoDB.Bson;

public class AppText : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public string Text{ get; set; }
    public int IdIdioma{ get; set; }
}