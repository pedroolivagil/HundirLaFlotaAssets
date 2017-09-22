using UnityEngine;

public class ScenesGame : MonoBehaviour{
    protected GameObject[] Dialogs;

    // Use this for initialization
    public void HideDialogsStart(){
        Dialogs = GameObject.FindGameObjectsWithTag(GameManager.DIALOG_TAG);
        foreach (GameObject dialog in Dialogs){
            dialog.SetActive(false);
        }
    }
}