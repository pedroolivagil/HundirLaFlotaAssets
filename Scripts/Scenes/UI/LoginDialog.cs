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
            User u = MapControllers.GetInstance().UserController.CheckLogin(user.text, pass.text);
            if (GameManager.IsNotNull(u)){
                Notifier.GetInstance().SendMessage("El usuario existe y se ha hecho login");
                GameManager.GetConfig().WriteConfig(Config.Section.User, Config.Key.ID, u.IdUser);
                GameManager.ChangeScreen(GameScenes.SinglePlayerBattleSelector, true);
            } else{
                Notifier.GetInstance().SendMessage("Error de login");
            }
        }
        // WriteConfig(Section.User, Key.ID, 0);
        // WriteConfig(Section.User, Key.AutoLogin, 0);

        /*WWWForm data = new WWWForm();
        data.AddField("usermail", user.text);
        data.AddField("password", pass.text);
        WWW response = DB.GetInstance().Post(DB.UrlLogin, data);
        string responseText = response.text;
        if (responseText != null){
            user.interactable = false;
            pass.interactable = false;
            JsonData responseJson = DB.ParseJSON(responseText);
            int responseCode = (int) responseJson[DB.RESPONSE_LABEL];
            string message;
            Debug.Log("aqui entra(" + responseCode + "): " + responseText);
            if (responseCode != GameManager.ResponseCode.CODE_200){
                user.interactable = true;
                pass.interactable = true;
                pass.text = null;
                if (responseCode == GameManager.ResponseCode.CODE_404){
                    Debug.Log("Conection Fail");
                    message = LocaleManager.GetInstance().TranslateStr("ERROR_USER_NOT_EXIST");
                }
                else{
                    Debug.Log("FAIL TO CONNECT SERVER");
                    message = LocaleManager.GetInstance().TranslateStr("ERROR_UNABLE_TO_CONNECT_SERVER");
                }
            }
            else{
                message = LocaleManager.GetInstance().TranslateStr("INFO_USER_EXIST");
            }
            Debug.Log("MSJ: " + message);
            Notifier.GetInstance().SendMessage(message);
        }*/
        GameManager.HideDialogConnection();
    }
}