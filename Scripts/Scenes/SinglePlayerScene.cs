using UnityEngine;

public class SinglePlayerScene : ScenesGame{
    public string DialogConfig = "DialogConfig";

    // Use this for initialization
    void Start(){
        HideDialogsStart();
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