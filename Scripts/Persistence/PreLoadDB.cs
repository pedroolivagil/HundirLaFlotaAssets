using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Borrar al generar la versión final
/// </summary>
public class PreLoadDb{
    private static PreLoadDb _instance;
    private readonly string _tableUser = "User";
    private readonly string _tablePowerup = "Powerup";
    private readonly string _tableScenario = "Scenario";
    private readonly string _tableCity = "City";
    private readonly string _tableMarket = "Market";
    private readonly string _tableBattle = "Battle";
    private readonly string _tableBank = "Bank";
    private readonly string _tableItem = "Item";
    private readonly string _tableInventory = "Inventory";
    private readonly string _tableVessel = "Vessel";
    private readonly string _tableWeapon = "Weapon";
    private readonly string _tableResource = "Resource";
    private readonly string _tableProfileAi = "ProfileAI";
    private readonly string _tableUserGame = "UserGame";
    private readonly string _tableAppText = "AppText";
    private readonly string _tableAppLocale = "AppLocale";
    private readonly string _tablePuerto = "Puerto";
    private readonly string _tableQuest = "Quest";
    private readonly string _tableReward = "Reward";

    public static PreLoadDb Inst(){
        if (_instance == null){
            _instance = new PreLoadDb();
        }
        return _instance;
    }

    public void CleanDb(){
        DB.Inst().RemoveCollection(_tableAppLocale);
        DB.Inst().RemoveCollection(_tableAppText);
        DB.Inst().RemoveCollection(_tableBank);
        DB.Inst().RemoveCollection(_tableBattle);
        DB.Inst().RemoveCollection(_tableCity);
        DB.Inst().RemoveCollection(_tableInventory);
        DB.Inst().RemoveCollection(_tableItem);
        DB.Inst().RemoveCollection(_tableMarket);
        DB.Inst().RemoveCollection(_tablePowerup);
        DB.Inst().RemoveCollection(_tableProfileAi);
        DB.Inst().RemoveCollection(_tablePuerto);
        DB.Inst().RemoveCollection(_tableQuest);
        DB.Inst().RemoveCollection(_tableResource);
        DB.Inst().RemoveCollection(_tableReward);
        DB.Inst().RemoveCollection(_tableScenario);
        DB.Inst().RemoveCollection(_tableUser);
        DB.Inst().RemoveCollection(_tableUserGame);
        DB.Inst().RemoveCollection(_tableVessel);
        DB.Inst().RemoveCollection(_tableWeapon);
    }

    public void CreateDb(){
        // Iniciamos las colecciones
        DB.Inst().NewCollection(_tableAppLocale);
        DB.Inst().NewCollection(_tableAppText);
        DB.Inst().NewCollection(_tableBank);
        DB.Inst().NewCollection(_tableBattle);
        DB.Inst().NewCollection(_tableCity);
        DB.Inst().NewCollection(_tableInventory);
        DB.Inst().NewCollection(_tableItem);
        DB.Inst().NewCollection(_tableMarket);
        DB.Inst().NewCollection(_tablePowerup);
        DB.Inst().NewCollection(_tableProfileAi);
        DB.Inst().NewCollection(_tablePuerto);
        DB.Inst().NewCollection(_tableQuest);
        DB.Inst().NewCollection(_tableResource);
        DB.Inst().NewCollection(_tableReward);
        DB.Inst().NewCollection(_tableScenario);
        DB.Inst().NewCollection(_tableUser);
        DB.Inst().NewCollection(_tableUserGame);
        DB.Inst().NewCollection(_tableVessel);
        DB.Inst().NewCollection(_tableWeapon);

        // Insertamos registros básicos
        //Barcos
        Vessel ship1 = new Vessel();
        ship1.Code = "ship_game_s";
        ship1.Health = 1;
        ship1.Inventory = 1;
        ship1.Weapon = 1;
        ship1.Trans = new[]{
            new GenericTrans{text = "Barco S", id_locale = 1},
            new GenericTrans{text = "Ship S", id_locale = 2}
        };
        Vessel ship2 = new Vessel();
        ship2.Code = "ship_game_m";
        ship2.Health = 0;
        ship2.Inventory = 0;
        ship2.Weapon = 0;
        ship2.Trans = new[]{
            new GenericTrans{text = "Barco M", id_locale = 1},
            new GenericTrans{text = "Ship M", id_locale = 2}
        };
        Vessel ship3 = new Vessel();
        ship3.Code = "ship_game_l";
        ship3.Health = 0;
        ship3.Inventory = 0;
        ship3.Weapon = 0;
        ship3.Trans = new[]{
            new GenericTrans{text = "Barco L", id_locale = 1},
            new GenericTrans{text = "Ship L", id_locale = 2}
        };
        Vessel ship4 = new Vessel();
        ship4.Code = "ship_game_xl";
        ship4.Health = 0;
        ship4.Inventory = 0;
        ship4.Weapon = 0;
        ship4.Trans = new[]{
            new GenericTrans{text = "Barco XL", id_locale = 1},
            new GenericTrans{text = "Ship XL", id_locale = 2}
        };
        Vessel ship5 = new Vessel();
        ship5.Code = "ship_game_xxl";
        ship5.Health = 0;
        ship5.Inventory = 0;
        ship5.Weapon = 0;
        ship5.Trans = new[]{
            new GenericTrans{text = "Barco XXL", id_locale = 1},
            new GenericTrans{text = "Ship XXL", id_locale = 2}
        };
        DbMngr.Inst().VesselController.Create(ship1);
        DbMngr.Inst().VesselController.Create(ship2);
        DbMngr.Inst().VesselController.Create(ship3);
        DbMngr.Inst().VesselController.Create(ship4);
        DbMngr.Inst().VesselController.Create(ship5);

        //Usuarios
        User u1 = new User();
        u1.Username = "admin";
        u1.Password = "1234";
        u1.Email = "admin@hundirflota.com";
        u1.Firstname = "Admin";
        u1.RolUser = Types.RolUsers.Admin;
        User u2 = new User();
        u2.Username = "user";
        u2.Password = "1234";
        u2.Email = "user@hundirflota.com";
        u2.Firstname = "User";
        u2.RolUser = Types.RolUsers.Admin;
        DbMngr.Inst().UserController.Create(u1);
        DbMngr.Inst().UserController.Create(u2);

        Reward rwd1 = new Reward();
        rwd1.TypeReward = Types.Reward.Gold;
        rwd1.Code = "first";
        rwd1.Value = 50d;
        Reward rwd2 = new Reward();
        rwd2.TypeReward = Types.Reward.Exp;
        rwd2.Code = "second";
        rwd2.Value = 100d;
        Reward rwd3 = new Reward();
        rwd3.TypeReward = Types.Reward.Vessel;
        rwd3.Code = "third";
        rwd3.Vessel = 5;
        Reward rwd4 = new Reward();
        rwd4.TypeReward = Types.Reward.Item;
        rwd4.Code = "fourth";
        rwd4.Item = 1;
        DbMngr.Inst().RewardController.Create(rwd1);
        DbMngr.Inst().RewardController.Create(rwd2);
        DbMngr.Inst().RewardController.Create(rwd3);
        DbMngr.Inst().RewardController.Create(rwd4);

        Battle battle = new Battle();
        battle.Code = "battle1";
        battle.Position = new Coordinates{X = 100, Y = 200};
        battle.PanelSize = new Coordinates{X = 6, Y = 6};
        battle.Trans = new[]{
            new GenericTrans{text = "Batalla Test", id_locale = 1},
            new GenericTrans{text = "Test Battle", id_locale = 2}
        };
        battle.CpuFog = false;
        battle.WinBeforeMinTime = false;
        battle.MaxTime = 100;
        battle.MinTime = 30;
        battle.MinLevel = 1;
        battle.AllowedCpuShips = new List<int>{
            1,
            2,
            3,
            4,
            5
        };
        battle.AllowedUserShips = new List<int>{
            1,
            2,
            3,
            4,
            5
        };
        battle.ProfileCpu = new List<int>{
            1
        };
        Reward rw1 = DbMngr.Inst().RewardController.FindByCode("first");
        battle.Rewards = new List<int>{
            rw1.IdReward
        };
        battle.AllowedPowerups = null;
        DbMngr.Inst().BattleController.Create(battle);

        Quest qst = new Quest();
        qst.Code = "quest1";
        qst.MinLevel = 1;
        Reward rw2 = DbMngr.Inst().RewardController.FindByCode("second");
        qst.Rewards = new List<int>{
            rw2.IdReward
        };
        qst.Description = new[]{
            new GenericTrans{
                text =
                    "Descripción de la misión. La misión consta de varios objetivos, como conseguir objetos, ciertas batallas, ...",
                id_locale = 1
            },
            new GenericTrans{
                text =
                    "Description of the mission. The mission consists of several objectives, such as getting objects, certain battles, ...",
                id_locale = 2
            }
        };
        qst.Trans = new[]{
            new GenericTrans{text = "Misión 1", id_locale = 1},
            new GenericTrans{text = "Quest 1", id_locale = 2}
        };
        DbMngr.Inst().QuestController.Create(qst);

        Market mrkt = new Market();
        mrkt.Code = "marketgame";
        mrkt.Items = null;
        mrkt.ItemsPurchase = null;
        DbMngr.Inst().MarketController.Create(mrkt);

        Harbor harbor = new Harbor();
        harbor.Code = "port_royal";
        harbor.Trans = new[]{
            new GenericTrans{text = "Puerto Real", id_locale = 1},
            new GenericTrans{text = "Port Royal", id_locale = 2}
        };
        harbor.PriceGemsRepair = 2;
        harbor.PriceGoldRepair = 1500;
        harbor.TimeGemsRepair = 100;
        harbor.TimeGoldRepair = 3600;
        DbMngr.Inst().HarborController.Create(harbor);

        City city = new City();
        city.Code = "caramelo";
        city.CrewSide = Types.CrewSide.Neutral;
        Market market = DbMngr.Inst().MarketController.FindByCode("marketgame");
        city.IdMarket = market.IdMarket;
        Harbor hbr = DbMngr.Inst().HarborController.FindByCode("marketgame");
        city.IdHarbor = hbr.IdHarbor;
        city.Position = new Coordinates{X = 100, Y = 100};
        city.Trans = new[]{
            new GenericTrans{text = "Ciudad Caramelo", id_locale = 1},
            new GenericTrans{text = "Candy City", id_locale = 2}
        };
        Battle btl = DbMngr.Inst().BattleController.FindByCode("battle1");
        city.Battles = new List<long>{
            btl.IdBattle
        };
        Resource cityResource = DbMngr.Inst().ResourceController.FindByCode("city");
        city.IdResource = cityResource.IdResource;
        Quest quest = DbMngr.Inst().QuestController.FindByCode("quest1");
        city.Quests = new List<long>{
            quest.IdQuest
        };
        DbMngr.Inst().CityController.Create(city);

        Scenario scn = new Scenario();
        scn.Code = "scenario_inicial";
        scn.MinLevel = 1;
        Resource scnResource = DbMngr.Inst().ResourceController.FindByCode("mapa");
        scn.Resource = scnResource.IdResource;
        scn.Trans = new[]{
            new GenericTrans{text = "Región Egmar", id_locale = 1},
            new GenericTrans{text = "Egmar region", id_locale = 2}
        };
        scn.RandomBattles = new List<Coordinates>{
            new Coordinates{X = 200, Y = 300},
            new Coordinates{X = 300, Y = 350}
        };
        Reward rw3 = DbMngr.Inst().RewardController.FindByCode("third");
        Reward rw4 = DbMngr.Inst().RewardController.FindByCode("fourth");
        scn.Rewards = new List<int>{
            rw3.IdReward,
            rw4.IdReward
        };
        City ct = DbMngr.Inst().CityController.FindByCode("caramelo");
        scn.Cities = new List<long>{
            ct.IdCity
        };
        DbMngr.Inst().ScenarioController.Create(scn);
    }
}