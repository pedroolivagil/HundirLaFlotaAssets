using System.Collections;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class DialogRecovery : MonoBehaviour{
    public InputField email;

    public void RecoveryPass(){
        /*DB.GetInstance().ShowDialogConnection();
        StartCoroutine(RecoveryPassword());*/
    }

    private IEnumerator RecoveryPassword(){
        yield return new WaitForSeconds(.5f);
        /*WWWForm data = new WWWForm();
        data.AddField("email", email.text);
        WWW response = DB.GetInstance().Post(DB.UrlRecoveryPass, data);
        string responseText = response.text;
        if (responseText != null){
            email.interactable = false;
            JsonData responseJson = DB.ParseJSON(responseText);
            int responseCode = (int) responseJson[DB.RESPONSE_LABEL];
            string message;
            Debug.Log("aqui entra(" + responseCode + "): " + responseText);
            if (responseCode != GameManager.ResponseCode.CODE_200){
                email.interactable = true;
                email.text = null;
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
                message = LocaleManager.GetInstance().TranslateStr(responseJson["message"].ToString());
            }
            Debug.Log("MSJ: " + message);
            Notifier.GetInstance().SendMessage(message);
        }*/
    }
}