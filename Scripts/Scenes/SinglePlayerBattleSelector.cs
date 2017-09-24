using System;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : ScenesGame{
    public RawImage mapa;

    // Use this for initialization
    void Start(){
        HideDialogsStart();
        User user = DbMngr.Inst().UserController.FindByUserName("admin");
        UserGame game = DbMngr.Inst().UserGameController.FindByIdUser(user.IdUser);
        if (game != null){
            Bank bank = DbMngr.Inst().BankController.FindById(game.Bank);
            Scenario scenario = DbMngr.Inst().ScenarioController.FindById(game.Scenario);
            Resource scenarioResource = DbMngr.Inst().ResourceController.FindById(scenario.Resource);
            if (GameManager.IsNotNull(scenarioResource.File)){
                mapa.texture = GameManager.ConvertBase64ToTexture2D(scenarioResource.File);
            }
            // PreLoadDb.Inst().CreateDb();
        }
    }
}