using MongoDB.Bson;

public class Powerup : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdPowerup{ get; set; }
    public int Value{ get; set; }
    public int Type{ get; set; }
    public int Usages{ get; set; }
    public int ReloadTime{ get; set; }
    public int MinLevel{ get; set; }
    public GenericTrans[] Trans{ get; set; }
}