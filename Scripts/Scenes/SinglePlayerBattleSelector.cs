using UnityEngine.UI;

public class SinglePlayerBattleSelector : ScenesGame{
    public RawImage mapa;
    private Resource scenarioResource;

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
            Notifier.Inst().SendMessage("Error al cargar el usuario");
        }
    }

    public void Init(){
        if (GameManager.GameData != null){
            scenarioResource = DbMngr.Inst().ResourceController.FindById(GameManager.GameData.Scenario.Resource);
            if (GameManager.IsNotNull(scenarioResource.File)){
                mapa.texture = GameManager.ConvertBase64ToTexture2D(scenarioResource.File);
            }
        } else{
            Notifier.Inst().SendMessage("Error al cargar los datos del usuario");
        }
    }

    public void ReturnToMenu(){
        GameManager.ChangeScreen(GameScenes.MainMenuScene, true);
    }
}