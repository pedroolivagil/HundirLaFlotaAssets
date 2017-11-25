using System.Collections.Generic;
using MongoDB.Bson;

public class Bank : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdBank{ get; set; }
    public int MaxTimeMoneyReward{ get; set; } // Tiempo de límite recarga de la recompensa
    public int TimeMoneyReward{ get; set; } // Tiempo de recarga de la recompensa
    public double SafeBox{ get; set; } // Caja fuerte
    public string accountNumber{ get; set; }
    public List<int> ItemsBox{ get; set; } // Items guardados
}