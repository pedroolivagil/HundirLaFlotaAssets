using UnityEngine;

public class MainMenuScene : MonoBehaviour{
    public string dialogExitGame = "DialogExitGame";
    public string dialogFormLogin = "DialogFormLogin";
    private GameObject[] Dialogs;

    private void Start(){
        Dialogs = GameObject.FindGameObjectsWithTag(GameManager.DIALOG_TAG);
        foreach (GameObject dialog in Dialogs){
            dialog.SetActive(false);
        }
    }

    public void ButtonPlayGame(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == dialogFormLogin){
                dialog.SetActive(true);
            }
        }
    }

    public void ButtonExitGame(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == dialogExitGame){
                dialog.SetActive(true);
            }
        }
    }

    public void ExitGame(){
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}