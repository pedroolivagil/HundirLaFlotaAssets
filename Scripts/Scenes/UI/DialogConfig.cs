using UnityEngine;
using UnityEngine.UI;

public class DialogConfig : MonoBehaviour{
    public Slider sliderM;
    public Slider sliderS;
    public Slider sliderD;
    private float sliderValueS;
    private float sliderValueM;
    private float sliderValueD;

    private void Start(){
        Init();
    }

    public void Init(){
        sliderValueS = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.SoundLevel);
        sliderValueM = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.MusicLevel);
        sliderValueD = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.Difficult);
        ResetValues();
    }

    public void ResetValues(){
        sliderS.value = sliderValueS;
        sliderM.value = sliderValueM;
        sliderD.value = sliderValueD;
    }

    public void UpdateSound(){
        GameManager.GetConfig().WriteConfig(Config.Section.PlayerSettings, Config.Key.SoundLevel, sliderS.value);
    }

    public void UpdateMusic(){
        GameManager.GetConfig().WriteConfig(Config.Section.PlayerSettings, Config.Key.MusicLevel, sliderM.value);
    }

    public void UpdateLevel(){
        GameManager.GetConfig().WriteConfig(Config.Section.PlayerSettings, Config.Key.Difficult, sliderD.value);
    }

    public void SaveConfigChanges(){
        GameManager.GetConfig().UpdateFile();
        Init();
    }
}