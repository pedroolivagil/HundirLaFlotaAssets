using MongoDB.Bson;

public class ProfileAI : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public int IdProfileAi{ get; set; }
    public int Accuracy{ get; set; } // Puntería
    public int Lucky{ get; set; } // Suerte
    public int Courage{ get; set; } // Coraje
    public int Level{ get; set; } // Nivel mínimo del usuario
    public int Wit{ get; set; } // Agudeza de acierto después del primero (de cada turno)
}