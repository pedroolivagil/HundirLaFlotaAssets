using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DB : MonoBehaviour{
    public static readonly string RESPONSE_LABEL = "response";
    public static readonly string UrlHost = "http://localhost/HundirLaFlota3DServer/";
    public static readonly string UrlLogin = "www/login.php";
    private static DB instance;
    private GameObject DialogConnection;

    public static DB GetInstance(){
        init();
        return instance;
    }

    private static void init(){
        if (instance == null){
            instance = new DB();
        }
        DontDestroyOnLoad(instance);
    }

    public static JsonData ParseJSON(string responseText){
        return JsonMapper.ToObject(responseText);
    }

    public void GetDialogConnection(){
        Canvas c = FindObjectOfType<Canvas>();
        Component[] objs = c.GetComponentsInChildren(typeof(Transform), true);
        foreach (Component gObj in objs){
            if (gObj.CompareTag(GameManager.DIALOG_TAG) && gObj.name == "DialogConnection"){
                DialogConnection = gObj.gameObject;
            }
        }
        Debug.Log(DialogConnection.name);
    }

    public WWW Get(string url){
        WWW www = new WWW(url);
        WaitForSeconds w;
        while (!www.isDone){
            w = new WaitForSeconds(0.1f);
        }
        HideDialogConnection();
        return www;
    }

    public WWW Post(string url, WWWForm form){
        WWW www = new WWW(UrlHost + url, form);
        WaitForSeconds w;
        while (!www.isDone){
            w = new WaitForSeconds(0.1f);
        }
        HideDialogConnection();
        return www;
    }

    public WWW Post(string url, Dictionary<string, string> post){
        WWWForm form = new WWWForm();
        foreach (var pair in post){
            form.AddField(pair.Key, pair.Value);
        }
        return Post(url, form);
    }

    public void ShowDialogConnection(){
        GetDialogConnection();
        DialogConnection.SetActive(true);
        Debug.Log("Show");
    }

    public void HideDialogConnection(){
        GetDialogConnection();
        DialogConnection.SetActive(false);
        Debug.Log("Hide");
    }
}