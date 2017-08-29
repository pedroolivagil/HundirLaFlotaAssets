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
                GameManager.ActiveDialog(dialog);
            }
        }
    }

    public void ButtonExitGame(){
        foreach (GameObject dialog in Dialogs){
            if (dialog.name == dialogExitGame){
                GameManager.ActiveDialog(dialog);
            }
        }
    }

    public void ExitGame(){
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}