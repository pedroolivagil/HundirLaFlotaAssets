using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour{
    private Slider slider;
    private Text text;
    public bool custom;
    public string[] textsCustom;

    void Start(){
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<Text>();
        if (!custom){
            slider.onValueChanged.AddListener(delegate{ UpdateTextSlider(); });
        }
        else{
            slider.onValueChanged.AddListener(delegate{ UpdateCustomTextSlider(); });
        }
    }

    private void UpdateCustomTextSlider(){
        if (text != null){
            text.text = LocaleManager.Inst().TranslateStr(textsCustom[(int) slider.value]);
        }
    }

    private void UpdateTextSlider(){
        if (text != null){
            text.text = slider.value + "";
        }
    }
}