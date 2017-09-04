using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerScene : MonoBehaviour{
    public string DialogConfig = "DialogConfig";

    private GameObject[] Dialogs;

    // Use this for initialization
    void Start(){
        Dialogs = GameObject.FindGameObjectsWithTag(GameManager.DIALOG_TAG);
        foreach (GameObject dialog in Dialogs){
            dialog.SetActive(false);
        }
    }

    public void ButtonConfig(){
        Time.timeScale = 0;
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == DialogConfig){
                GameManager.ActiveDialog(dialog);
            }
        }
    }
}