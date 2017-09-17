using MongoDB.Bson;

public class Resource : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdResource{ get; set; }
    public string Name{ get; set; }
    public string MimeType{ get; set; }
    public string File{ get; set; }
    public int Size{ get; set; }
}