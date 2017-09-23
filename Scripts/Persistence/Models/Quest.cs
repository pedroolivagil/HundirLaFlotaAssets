using System.Collections.Generic;
using MongoDB.Bson;

public class Quest : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdQuest{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public GenericTrans[] Description{ get; set; }
    public List<int> Rewards{ get; set; } //IDs reward
    public int MinLevel{ get; set; }
    public long ExpiryDate{ get; set; } // fecha de caducidad
}