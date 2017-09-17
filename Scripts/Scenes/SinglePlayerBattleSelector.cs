using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : MonoBehaviour{
    public Image mapa;

    // Use this for initialization
    void Start(){
        User user = MapControllers.GetInstance().UserController.FindByUserName("Insert");
        Debug.Log(user.Firstname);
    }

    
}