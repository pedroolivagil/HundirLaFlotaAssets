using UnityEngine;

public class MainMenuScene : ScenesGame{
    public string dialogExitGame = "DialogExitGame";
    public string dialogFormLogin = "DialogFormLogin";
    public string DialogConfig = "DialogConfig";

    private void Start(){
        HideDialogsStart();
    }

    public void ButtonPlayGame(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == dialogFormLogin){
                GameManager.ActiveDialog(dialog);
            }
        }
    }

    public void ButtonPlayOnlineGame(){
        Notifier.GetInstance().SendMessage(LocaleManager.Inst().TranslateStr("INFO_DEVELOP_FUNCTION"));
    }

    public void ButtonConfig(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == DialogConfig){
                GameManager.ActiveDialog(dialog);
            }
        }
    }

    public void ButtonExitGame(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == dialogExitGame){
                GameManager.ActiveDialog(dialog);
            }
        }
    }

    public void ExitGame(){
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}