using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour{
    public Slider sliderM;
    public Slider sliderS;
    public Slider sliderD;

    private void Start(){
        sliderS.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.SoundLevel));
        sliderM.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.MusicLevel));
        sliderD.value = Convert.ToSingle(ReadIni.IniReadValue(ReadIni.Section.PlayerSettings, ReadIni.Key.Difficult));
        
    }

    public void UpdateSound(){
        ReadIni.IniWriteValue(ReadIni.Section.PlayerSettings, ReadIni.Key.SoundLevel, sliderS.value.ToString());
    }

    public void UpdateMusic(){
        ReadIni.IniWriteValue(ReadIni.Section.PlayerSettings, ReadIni.Key.MusicLevel, sliderM.value.ToString());
    }

    public void UpdateLevel(){
        ReadIni.IniWriteValue(ReadIni.Section.PlayerSettings, ReadIni.Key.Difficult, sliderD.value.ToString());
    }

    public void SaveConfigChanges(){
        ReadIni.UpdateIni();
    }
}