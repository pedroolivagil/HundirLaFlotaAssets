using MongoDB.Bson;

public class User : _Entity{
    public ObjectId _id{ get; set; }
    public bool FlagActive{ get; set; }
    public long EntryDate{ get; set; }
    public string Code{ get; set; }

    public long IdUser{ get; set; }
    public long Birthday{ get; set; }
    public bool AcountActive{ get; set; }
    public int Gender{ get; set; }
    public int RolUser{ get; set; }
    public string Username{ get; set; }
    public string Password{ get; set; }
    public string Email{ get; set; }
    public string Firstname{ get; set; }
    public string Lastname{ get; set; }
    public string EmailSecurity{ get; set; }
    public string Phone{ get; set; }
    public string Address{ get; set; }
    public string Country{ get; set; }
    public string State{ get; set; }
}