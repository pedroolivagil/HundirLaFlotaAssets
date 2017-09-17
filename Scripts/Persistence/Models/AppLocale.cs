using MongoDB.Bson;

public class AppLocale : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; } //CODE ISO

    public int IdAppLocale{ get; set; }
    public GenericTrans[] Trans{ get; set; }
}