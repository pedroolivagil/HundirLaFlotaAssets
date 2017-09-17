using System.Collections.Generic;
using MongoDB.Bson;

public class Inventory : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdInventory{ get; set; }
    public List<int> Items{ get; set; } // IDs de los item del usuario
    public int MaxItems{ get; set; } // máximo de items en el invetario
}