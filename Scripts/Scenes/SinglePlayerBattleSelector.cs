using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : MonoBehaviour{
    public int MockIDUser;
    public Image mapa;
    public JsonData response;

    // Use this for initialization
    void Start(){
        if (MockIDUser > 0){
            Dictionary<string, string> form = new Dictionary<string, string>();
            form.Add("idUser", MockIDUser.ToString());
            var resp = StartCoroutine(DBFunctions.GetInstance().Connect(DB.UrlUserGame, form, "TodoCorrecto"));
            if (resp != null){
                response = DBFunctions.GetInstance().GetResponse();
                Debug.Log(response[DB.RESPONSE_LABEL]);
            }
        }
    }
}