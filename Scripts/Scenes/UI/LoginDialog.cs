using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class LoginDialog : MonoBehaviour{
    public InputField user;
    public InputField pass;

    public void RecoveryPass(){
        Component c = GameManager.GetComponentWithName("DialogRecoveryPass");
        if (c != null){
            GameManager.ActiveDialog(c.gameObject);
        }
    }

    public void SignUp(){
        Component c = GameManager.GetComponentWithName("DialogFormSignUp");
        if (c != null){
            GameManager.ActiveDialog(c.gameObject);
        }
    }

    public void LoginUser(){
        GameManager.ShowDialogConnection();
        Login();
    }

    private void Login(){
        if (GameManager.IsNull(user.text) || GameManager.IsNull(pass.text)){
            Notifier.GetInstance().SendMessage(LocaleManager.GetInstance().TranslateStr("ERROR_FORM_EMPTY"));
        } else{
            User u = DbMngr.Inst().UserController.CheckLogin(user.text, pass.text);
            if (GameManager.IsNotNull(u)){
                GameManager.userGame = u;
                GameManager.GetConfig().WriteConfig(Config.Section.User, Config.Key.ID, u.IdUser);
                GameManager.ChangeScreen(GameScenes.SinglePlayerBattleSelector, true);
            } else{
                Notifier.GetInstance().SendMessage(
                    LocaleManager.GetInstance().TranslateStr("ERROR_USER_NOT_EXIST"));
            }
        }
        GameManager.HideDialogConnection();
    }
}