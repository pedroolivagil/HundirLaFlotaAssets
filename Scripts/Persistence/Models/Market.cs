using System.Collections.Generic;
using MongoDB.Bson;

public class Market : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdMarket{ get; set; }
    public List<int> Items{ get; set; } // IDs de Items asociados al market
    public List<int> ItemsPurchase{ get; set; } // IDs de los items de compra (compra real)
}