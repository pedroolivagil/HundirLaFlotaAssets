using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    private Text timer;
    private int time;
    int mins = 0;
    int seconds = 0;

    void Start(){
        time = 0;
        timer = GetComponentInChildren<Text>();
        timer.text = "00:00";
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer(){
        yield return new WaitForSeconds(1f);
        timer.text = CalcTimeText();
        yield return UpdateTimer();
    }

    private string CalcTimeText(){
        time++;
        if (time % 60 == 0){
            mins++;
            seconds = 0;
        }
        else{
            seconds++;
        }
        String text = "";
        String minsText = "";
        String secsText = "";
        if (mins < 10){
            minsText = "0" + mins;
        }
        else{
            minsText = "" + mins;
        }
        if (seconds < 10){
            secsText = "0" + seconds;
        }
        else{
            secsText = "" + seconds;
        }
        text = minsText + ":" + secsText;
        return text;
    }
}