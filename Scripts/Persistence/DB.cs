using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DB : MonoBehaviour{
    public static readonly string RESPONSE_LABEL = "response";
    public static readonly string UrlHost = "http://localhost/HundirLaFlota3DServer/";
    public static readonly string UrlLogin = "www/login.php";
    public static readonly string UrlUserGame = "www/usergame.php";
    public static readonly string UrlSignUp = "www/signup.php";
    public static readonly string UrlRecoveryPass= "www/recovery_pass.php";
    private static DB instance;
    private GameObject DialogConnection;

    public static DB GetInstance(){
        init();
        return instance;
    }

    private static void init(){
        if (instance == null){
            instance = new DB();
            DontDestroyOnLoad(instance);
        }
    }

    public static JsonData ParseJSON(string responseText){
        return JsonMapper.ToObject(responseText);
    }

    public void GetDialogConnection(){
        Component c = GameManager.GetComponentWithName("DialogConnection");
        if (c != null){
            DialogConnection = c.gameObject;
        }
    }

    public WWW Get(string url){
        WWW www = new WWW(url);
        while (!www.isDone){ }
        HideDialogConnection();
        return www;
    }

    public WWW Post(string url, WWWForm form){
        WWW www = new WWW(UrlHost + url, form);
        while (!www.isDone){ }
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
        GameManager.ActiveDialog(DialogConnection);
    }

    public void HideDialogConnection(){
        GetDialogConnection();
        DialogConnection.SetActive(false);
    }
}