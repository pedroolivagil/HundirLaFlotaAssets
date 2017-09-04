using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogConfig : MonoBehaviour{
    public Slider sliderM;
    public Slider sliderS;
    public Slider sliderD;

    private void Start(){
        Init();
    }

    public void Init(){
/*        sliderS.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.SoundLevel));
        sliderM.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.MusicLevel));
        sliderD.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.Difficult));*/
        sliderS.value = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.SoundLevel);
        sliderM.value = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.MusicLevel);
        sliderD.value = GameManager.GetConfig().ReadConfigFloat(Config.Section.PlayerSettings, Config.Key.Difficult);
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