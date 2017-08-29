﻿using System.Collections;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class SignUpDialog : MonoBehaviour{
    public InputField username;
    public InputField pass1;
    public InputField pass2;
    public InputField email;

    public void SignUpUser(){
        /**/
        DB.GetInstance().ShowDialogConnection();
        if (pass1.text.Equals(pass2.text)){
            StartCoroutine(SignUp());
        }
        else{
            Notifier.GetInstance().SendMessage(LocaleManager.GetInstance().TranslateStr("ERROR_PWD_NOT_EQUALS"));
        }
    }

    private IEnumerator SignUp(){
        yield return new WaitForSeconds(0.5f);
        WWWForm data = new WWWForm();
        data.AddField("username", username.text);
        data.AddField("password", pass1.text);
        data.AddField("email", email.text);
        WWW response = DB.GetInstance().Post(DB.UrlSignUp, data);
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
                    message = LocaleManager.GetInstance().TranslateStr(responseJson["message"].ToString());
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
        }
    }
}