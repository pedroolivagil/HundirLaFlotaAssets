using System;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : MonoBehaviour{
    public int MockIDUser;
    public Image mapa;

    // Use this for initialization
    void Start(){
        if (MockIDUser > 0){
            testMongo();
        }
    }

    public void testMongo(){
        UserController userCon = new UserController();
        User user = userCon.FindById(MockIDUser);
        if (user != null){
            Debug.Log("User: " + user.Firstname);
            user.Code = userCon.GenerateCode(user);
            userCon.Update(user);
        }
        else{
            Debug.Log("El usuario no existe");
        }
    }
}