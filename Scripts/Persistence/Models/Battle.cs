using System.Collections.Generic;
using MongoDB.Bson;
using UnityEngine;

public class Battle : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdBattle{ get; set; }
    public int MinTime{ get; set; } // Tiempo mínimo que ha de aguantar el usuario para ganar y no perder.
    public int MaxTime{ get; set; } // Tiempo límite para ganar.
    public int MinLevel{ get; set; } // UserLevel mínimo para jugar esta batalla
    public bool WinBeforeMinTime{ get; set; } // Permite o no, ganar antes de tiempo.
    public bool CpuFog{ get; set; } // boolean para des/habilitar la niebla del enemigo
    public GenericTrans[] Trans{ get; set; }
    public Coordinates Position{ get; set; } // coordenadas de la batalla
    public Coordinates PanelSize{ get; set; } // Tamaño del tablero. 8x8, 10x10,...
    public List<int> Rewards{ get; set; } // IDs de las rewards.
    public List<int> AllowedPowerups{ get; set; } // IDs de los powerups permitidos.
    public List<int> AllowedUserShips{ get; set; } // IDs de los buques del usurio permitidos.
    public List<int> AllowedCpuShips{ get; set; } // IDs de los buques enemigos permitidos.
    public List<int> ProfileCpu{ get; set; } // IDs del perfil del enemigo.
}