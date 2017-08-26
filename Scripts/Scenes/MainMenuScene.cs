using UnityEngine;

public class MainMenuScene : MonoBehaviour{
    public GameObject Dialog;

    public void ButtonExitGame(){
        if (Dialog != null){
            Dialog.SetActive(true);
        }
    }

    public void ExitGame(){
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}