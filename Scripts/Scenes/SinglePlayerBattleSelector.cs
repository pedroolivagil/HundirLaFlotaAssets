using UnityEngine.UI;

public class SinglePlayerBattleSelector : ScenesGame{
    public RawImage Mapa;
    private Resource _scenarioResource;

    // Use this for initialization
    void Start(){
        HideDialogsStart();
        // PreLoadDb.Inst().CreateDb();
        User user = DbMngr.Inst().UserController.FindByUserName("admin");
        GameManager.User = user;
        
        if (GameManager.User != null){
            UserGame game = DbMngr.Inst().UserGameController.FindByIdUser(GameManager.User.IdUser);
            if (game != null){
                Bank bank = DbMngr.Inst().BankController.FindById(game.Bank);
                Scenario scenario = DbMngr.Inst().ScenarioController.FindById(game.Scenario);
                GameUserData gameUserData = new GameUserData{
                    Bank = bank,
                    Scenario = scenario,
                    UGame = game
                };
                GameManager.GameData = gameUserData;
            }
            Init();
        } else{
            ReturnToMenu(false);
        }
    }

    public void Init(){
        if (GameManager.GameData != null){
            _scenarioResource = DbMngr.Inst().ResourceController.FindById(GameManager.GameData.Scenario.Resource);
            if (GameManager.IsNotNull(_scenarioResource.File)){
                Mapa.texture = GameManager.ConvertBase64ToTexture2D(_scenarioResource.File);
            }
        } else{
            ReturnToMenu(false);
        }
    }

    public void ReturnToMenu(bool preload){
        GameManager.ChangeScreen(GameScenes.MainMenuScene, preload);
    }
}