using UnityEngine;
using UnityEngine.UI;

public class SceneTranlatable : MonoBehaviour{
    // Use this for initialization
    public Text[] excludeTranslate;

    private void Awake(){
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
                string texto = LocaleManager.Inst().TranslateStr(item.text.Trim());
                item.text = texto;
            }
        }
    }
}