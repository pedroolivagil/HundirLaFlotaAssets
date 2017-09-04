using UnityEngine;

public class DialogUI : MonoBehaviour{
    
    public void Cancel(){
        HideDialog();
    }

    public void Accept(){
        HideDialog();
    }

    private void HideDialog(){
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}