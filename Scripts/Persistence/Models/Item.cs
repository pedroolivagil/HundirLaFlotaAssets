using MongoDB.Bson;

public class Item : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdItem{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public double ItemPrice{ get; set; }
    public string Description{ get; set; }
    public int MinLevel{ get; set; }
    public long ExpiryDate{ get; set; } // fecha de caducidad
}