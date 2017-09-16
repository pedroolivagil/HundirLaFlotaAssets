using MongoDB.Bson;

public interface _Entity{
    ObjectId _id{ get; set; }
    bool FlagActive{ get; set; }
    long EntryDate{ get; set; }
    string Code{ get; set; }
}