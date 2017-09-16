public class MapControllers{
    private static MapControllers _instance;
    public UserController UserController{ get; private set; }

    public MapControllers(){
        UserController = new UserController();
    }

    public static MapControllers GetInstance(){
        if (_instance == null){
            _instance = new MapControllers();
        }
        return _instance;
    }
}