using System.Collections;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class SignUpDialog : MonoBehaviour{
    public InputField username;
    public InputField pass1;
    public InputField pass2;
    public InputField email;
    public Toggle terms;

    public void SignUpUser(){
        if (!terms.isOn){
            Notifier.GetInstance().SendMessage(LocaleManager.Inst().TranslateStr("ERROR_ACCEPT_TERMS"));
        }
        else if (pass1.text == "" || pass2.text == "" || !pass1.text.Equals(pass2.text)){
            Notifier.GetInstance().SendMessage(LocaleManager.Inst().TranslateStr("ERROR_PWD_NOT_EQUALS"));
        }
        else{
            /*DB.Inst().ShowDialogConnection();
            StartCoroutine(SignUp());*/
        }
    }

    private IEnumerator SignUp(){
        yield return new WaitForSeconds(0.5f);
        /*WWWForm data = new WWWForm();
        data.AddField("username", username.text);
        data.AddField("password", pass1.text);
        data.AddField("email", email.text);
        WWW response = DB.Inst().Post(DB.UrlSignUp, data);

        string responseText = response.text;
        if (responseText != null){
            username.interactable = false;
            pass1.interactable = false;
            pass2.interactable = false;
            email.interactable = false;
            JsonData responseJson = DB.ParseJSON(responseText);
            int responseCode = (int) responseJson[DB.RESPONSE_LABEL];
            string message;
            Debug.Log("aqui entra(" + responseCode + "): " + responseText);
            if (responseCode != GameManager.ResponseCode.CODE_200){
                username.interactable = true;
                pass1.interactable = true;
                email.interactable = true;
                pass2.interactable = true;
                pass2.text = null;
                if (responseCode == GameManager.ResponseCode.CODE_404){
                    Debug.Log("Conection Fail");
                    message = LocaleManager.Inst().TranslateStr(responseJson["message"].ToString());
                }
                else{
                    Debug.Log("FAIL TO CONNECT SERVER");
                    message = LocaleManager.Inst().TranslateStr("ERROR_UNABLE_TO_CONNECT_SERVER");
                }
            }
            else{
                message = LocaleManager.Inst().TranslateStr("INFO_NEW_USER");
                StartCoroutine(HideDialog());
            }
            Debug.Log("MSJ: " + message);
            Notifier.Inst().SendMessage(message);
        }*/
    }

    public IEnumerator HideDialog(){
        yield return new WaitForSeconds(.5f);
        DialogUI dialog = GetComponent<DialogUI>();
        username.text = null;
        pass1.text = null;
        pass2.text = null;
        email.text = null;
        dialog.Cancel();
    }
}