using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class DBFunctions{
    private static DBFunctions instance;
    private JsonData response;

    public static DBFunctions GetInstance(){
        init();
        return instance;
    }

    private static void init(){
        if (instance == null){
            instance = new DBFunctions();
        }
    }

    public IEnumerator Connect(string url, Dictionary<string, string> dataForm, string msgOk){
        yield return new WaitForSeconds(0.5f);
        WWWForm data = new WWWForm();
        foreach (KeyValuePair<string, string> form in dataForm){
            data.AddField(form.Key, form.Value);
        }
        WWW result = DB.GetInstance().Post(url, data);
        string responseText = result.text;
        if (responseText != null){
            JsonData responseJson = DB.ParseJSON(responseText);
            int responseCode = (int) responseJson[DB.RESPONSE_LABEL];
            string message;
            if (responseCode != GameManager.ResponseCode.CODE_200){
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
                message = LocaleManager.GetInstance().TranslateStr(msgOk);
            }
            Debug.Log("MSJ: " + message);
            Notifier.GetInstance().SendMessage(message);
            response = responseJson;
        }
    }

    public IEnumerator Connect(string url, Dictionary<string, InputField> dataForm, string msgOk){
        yield return new WaitForSeconds(0.5f);
        WWWForm data = new WWWForm();
        foreach (KeyValuePair<string, InputField> form in dataForm){
            data.AddField(form.Key, form.Value.text);
        }
        WWW result = DB.GetInstance().Post(url, data);
        string responseText = result.text;
        if (responseText != null){
            foreach (KeyValuePair<string, InputField> form in dataForm){
                form.Value.interactable = false;
            }
            JsonData responseJson = DB.ParseJSON(responseText);
            int responseCode = (int) responseJson[DB.RESPONSE_LABEL];
            string message;
            if (responseCode != GameManager.ResponseCode.CODE_200){
                foreach (KeyValuePair<string, InputField> form in dataForm){
                    form.Value.interactable = false;
                    form.Value.text = null;
                }
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
                message = LocaleManager.GetInstance().TranslateStr(msgOk);
            }
            Debug.Log("MSJ: " + message);
            Notifier.GetInstance().SendMessage(message);
            response = responseJson;
        }
    }

    public JsonData GetResponse(){
        return response;
    }
}