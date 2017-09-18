using UnityEditor;
using UnityEngine.Networking;

public class MapControllers{
    private static MapControllers _instance;
    public AppLocaleController AppLocaleController{ get; private set; }
    public AppTextController AppTextController{ get; private set; }
    public BankController BankController{ get; private set; }
    public BattleController BattleController{ get; private set; }
    public CityController CityController{ get; private set; }
    public InventoryController InventoryController{ get; private set; }
    public ItemController ItemController{ get; private set; }
    public MarketController MarketController{ get; private set; }
    public PowerupController PowerupController{ get; private set; }
    public ProfileAIController ProfileAiController{ get; private set; }
    public ResourceController ResourceController{ get; private set; }
    public ScenarioController ScenarioController{ get; private set; }
    public UserController UserController{ get; private set; }
    public UserGameGameController UserGameGameController{ get; private set; }
    public VesselController VesselController{ get; private set; }
    public WeaponController WeaponController{ get; private set; }

    public MapControllers(){
        UserController = new UserController();
        AppLocaleController = new AppLocaleController();
        AppTextController = new AppTextController();
        BankController = new BankController();
        BattleController = new BattleController();
        CityController = new CityController();
        InventoryController = new InventoryController();
        ItemController = new ItemController();
        MarketController = new MarketController();
        PowerupController = new PowerupController();
        ProfileAiController = new ProfileAIController();
        ResourceController = new ResourceController();
        ScenarioController = new ScenarioController();
        UserGameGameController = new UserGameGameController();
        VesselController = new VesselController();
        WeaponController = new WeaponController();
    }

    public static MapControllers GetInstance(){
        if (_instance == null){
            _instance = new MapControllers();
        }
        return _instance;
    }
}