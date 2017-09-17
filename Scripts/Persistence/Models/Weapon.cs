using MongoDB.Bson;

public class Weapon : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdWeapon{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public int Damage{ get; set; }
}