using MongoDB.Bson;

public class Reward : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdReward{ get; set; }
    public int TypeReward{ get; set; }
    public double Value{ get; set; } // Si es un typo Gold y Exp
    public int Vessel{ get; set; } // ID del barco
    public int Item{ get; set; } // ID del item
}