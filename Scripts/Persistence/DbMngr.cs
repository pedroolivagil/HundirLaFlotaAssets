using System;

public class DbMngr{
    private static DbMngr _instance;
    public AppLocaleController AppLocaleController{ get; private set; }
    public AppTextController AppTextController{ get; private set; }
    public BankController BankController{ get; private set; }
    public BattleController BattleController{ get; private set; }
    public CityController CityController{ get; private set; }
    public HarborController HarborController{ get; private set; }
    public InventoryController InventoryController{ get; private set; }
    public ItemController ItemController{ get; private set; }
    public MarketController MarketController{ get; private set; }
    public PowerupController PowerupController{ get; private set; }
    public ProfileAIController ProfileAiController{ get; private set; }
    public QuestController QuestController{ get; private set; }
    public ResourceController ResourceController{ get; private set; }
    public RewardController RewardController{ get; private set; }
    public ScenarioController ScenarioController{ get; private set; }
    public UserController UserController{ get; private set; }
    public UserGameController UserGameController{ get; private set; }
    public VesselController VesselController{ get; private set; }
    public WeaponController WeaponController{ get; private set; }

    public DbMngr(){
        UserController = new UserController();
        AppLocaleController = new AppLocaleController();
        AppTextController = new AppTextController();
        BankController = new BankController();
        BattleController = new BattleController();
        CityController = new CityController();
        HarborController = new HarborController();
        InventoryController = new InventoryController();
        ItemController = new ItemController();
        MarketController = new MarketController();
        PowerupController = new PowerupController();
        ProfileAiController = new ProfileAIController();
        QuestController = new QuestController();
        ResourceController = new ResourceController();
        RewardController = new RewardController();
        ScenarioController = new ScenarioController();
        UserGameController = new UserGameController();
        VesselController = new VesselController();
        WeaponController = new WeaponController();
    }

    public static DbMngr Inst(){
        if (_instance == null){
            _instance = new DbMngr();
        }
        return _instance;
    }

    public void Persist<T>(_Entity entity){
        if (typeof(T) == typeof(User)){
            UserController.Create((User) entity);
        } else if (typeof(T) == typeof(AppLocale)){
            AppLocaleController.Create((AppLocale) entity);
        } else if (typeof(T) == typeof(AppText)){
            AppTextController.Create((AppText) entity);
        } else if (typeof(T) == typeof(Bank)){
            BankController.Create((Bank) entity);
        } else if (typeof(T) == typeof(Battle)){
            BattleController.Create((Battle) entity);
        } else if (typeof(T) == typeof(City)){
            CityController.Create((City) entity);
        } else if (typeof(T) == typeof(Harbor)){
            HarborController.Create((Harbor) entity);
        } else if (typeof(T) == typeof(Inventory)){
            InventoryController.Create((Inventory) entity);
        } else if (typeof(T) == typeof(Item)){
            ItemController.Create((Item) entity);
        } else if (typeof(T) == typeof(Market)){
            MarketController.Create((Market) entity);
        } else if (typeof(T) == typeof(Powerup)){
            PowerupController.Create((Powerup) entity);
        } else if (typeof(T) == typeof(ProfileAI)){
            ProfileAiController.Create((ProfileAI) entity);
        } else if (typeof(T) == typeof(Quest)){
            QuestController.Create((Quest) entity);
        } else if (typeof(T) == typeof(Resource)){
            ResourceController.Create((Resource) entity);
        } else if (typeof(T) == typeof(Reward)){
            RewardController.Create((Reward) entity);
        } else if (typeof(T) == typeof(Scenario)){
            ScenarioController.Create((Scenario) entity);
        } else if (typeof(T) == typeof(UserGame)){
            UserGameController.Create((UserGame) entity);
        } else if (typeof(T) == typeof(Vessel)){
            VesselController.Create((Vessel) entity);
        } else if (typeof(T) == typeof(Weapon)){
            WeaponController.Create((Weapon) entity);
        } else{
            throw new Exception("Controller not implemented yet.");
        }
    }
}