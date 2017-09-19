using System;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : MonoBehaviour{
    public RawImage mapa;

    // Use this for initialization
    void Start(){
        User user = MapControllers.GetInstance().UserController.FindByUserName("Insert");
        Debug.Log(user.Firstname);
        Debug.Log("GUID: " + Guid.NewGuid());
        Resource resource = MapControllers.GetInstance().ResourceController.FindByCode("MAPA");
        Debug.Log("Resource: " + resource.Name);

        if (GameManager.IsNotNull(resource.File)){
            mapa.texture = GameManager.ConvertBase64ToTexture2D(resource.File);
        }
    }
}