using System.Collections;
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
            testMongo();
        }
    }

    public void testMongo(){
        UserController userCon = new UserController();
        Debug.Log("User: " + userCon.FindById(MockIDUser));
    }
}