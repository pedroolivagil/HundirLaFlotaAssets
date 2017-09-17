using System.Collections.Generic;
using MongoDB.Bson;

public class City : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdCity{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public List<int> Battles{ get; set; } // IDs de las batallas de cada mapa
    public bool CrewSide{ get; set; } // Booleano para el bando de la ciudad (enemigo o aliado)
    public List<int> Quests{ get; set; } // Objetivos para las ciudades, batallas, etc, ...
    public int IdMarket{ get; set; } // Mercado asociado a la ciudad
    public int IdResource{ get; set; } // ID resource asociado
}