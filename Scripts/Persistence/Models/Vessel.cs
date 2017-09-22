using MongoDB.Bson;

public class Vessel : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; } // prefabName

    public int IdVessel{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public int Health{ get; set; }
    public int Inventory{ get; set; }
    public int Weapon{ get; set; } //ID arma extra que usa
}