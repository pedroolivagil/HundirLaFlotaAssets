using UnityEngine;

public class DialogUI : MonoBehaviour{
    
    public void Cancel(){
        HideDialog();
    }

    public void Accept(){
        HideDialog();
    }

    private void HideDialog(){
        gameObject.SetActive(false);
    }
}