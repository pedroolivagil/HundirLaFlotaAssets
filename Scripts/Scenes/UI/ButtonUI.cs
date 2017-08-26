using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour{
    public string NameMainText = "mainText";

    private void Awake(){
        Text[] hijos = GetComponentsInChildren<Text>();
        string mainText = "";
        foreach (Text texto in hijos){
            if (texto.name == NameMainText){
                mainText = texto.text;
                break;
            }
        }
        foreach (Text texto in hijos){
            if (texto.name != NameMainText){
                texto.text = mainText;
            }
        }
    }
}