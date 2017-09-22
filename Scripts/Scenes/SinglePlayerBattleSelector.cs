using System;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : ScenesGame{
    public RawImage mapa;
    public RawImage city;

    // Use this for initialization
    void Start(){
        HideDialogsStart();
//
//        User user = DbMngr.Inst().UserController.FindByUserName("Insert");
//        Debug.Log(user.Firstname);
//        Debug.Log("GUID: " + Guid.NewGuid());
//        Resource cityResource = DbMngr.Inst().ResourceController.FindByCode("city");
//        Resource resource = DbMngr.Inst().ResourceController.FindByCode("MAPA");
//        Debug.Log("Resource: " + resource.Name);
//
//        if (GameManager.IsNotNull(resource.File)){
//            mapa.texture = GameManager.ConvertBase64ToTexture2D(resource.File);
//        }
//        if (GameManager.IsNotNull(cityResource.File)){
//            city.texture = GameManager.ConvertBase64ToTexture2D(cityResource.File);
//        }
//        Debug.Log("LastID: "+DbMngr.Inst().VesselController.GetLastId());
        PreLoadDb.Inst().CreateDb();
    }
}