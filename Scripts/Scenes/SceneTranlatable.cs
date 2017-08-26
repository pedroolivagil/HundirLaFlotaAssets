using UnityEngine;
using UnityEngine.UI;

public class SceneTranlatable : MonoBehaviour{
    // Use this for initialization
    public Text[] excludeTranslate;

    void Start(){
        ReplaceText();
    }

    private void ReplaceText(){
        Object[] objects = FindObjectsOfType(typeof(Text));
        foreach (Object obj in objects){
            Text item = (Text) obj;
            if (item != null && item.gameObject.activeInHierarchy){
                if (excludeTranslate != null && GameManager.ArrayContains(excludeTranslate, item)){
                    continue;
                }
                string texto = LocaleManager.GetInstance().TranslateStr(item.text.Trim());
                item.text = texto;
            }
        }
    }
}