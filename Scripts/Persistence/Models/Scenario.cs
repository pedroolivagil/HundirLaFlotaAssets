using System.Collections.Generic;
using MongoDB.Bson;
using UnityEngine;

public class Scenario : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdScenario{ get; set; }
    public int MinLevel{ get; set; }
    public GenericTrans[] Trans{ get; set; }
    public int Resource{ get; set; } // ID del resource
    public List<int> Rewards{ get; set; } // IDs de las rewards
    public List<int> Cities{ get; set; } // IDs de las batallas de cada mapa
    public List<Vector2> RandomBattles{ get; set; } // Array de coordenadas para las batallas random
}