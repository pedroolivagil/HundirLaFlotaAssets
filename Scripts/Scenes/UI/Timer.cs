using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    public int timeSeconds;
    public bool countDown;

    private Text timer;
    private int time;
    float mins = 0;
    float secs = 0;

    void Start(){
        timer = GetComponentInChildren<Text>();
        if (countDown){
            InitCountDown();
        }
        else{
            InitCounter();
        }
    }

    public void InitCountDown(){
        time = timeSeconds;
        timer.text = "00:00";
        StartCoroutine(UpdateTimerCountDown());
    }

    private void InitCounter(){
        time = timeSeconds;
        timer.text = "00:00";
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer(){
        yield return new WaitForSeconds(1f);
        timer.text = CalcTimeText();
        if (time < 6039){
            yield return UpdateTimer();
        }
    }

    private IEnumerator UpdateTimerCountDown(){
        yield return new WaitForSeconds(1f);
        timer.text = CalcTimeTextCountDown();
        if (time > 0){
            yield return UpdateTimerCountDown();
        }
    }

    private string CalcTimeText(){
        String text = "";
        String minsText = "";
        String secsText = "";
        time++;
        Debug.Log("Time: " + time);
        if (time % 60 == 0){
            mins++;
            secs = 0;
        }
        else{
            secs++;
        }
        if (mins < 10){
            minsText = "0" + mins;
        }
        else{
            minsText = "" + mins;
        }
        if (secs < 10){
            secsText = "0" + secs;
        }
        else{
            secsText = "" + secs;
        }
        text = minsText + ":" + secsText;
        return text;
    }

    private string CalcTimeTextCountDown(){
        String text = "";
        String minsText = "";
        String secsText = "";
        time--;
        mins = time / 60;
        secs = ((time / 60f) - mins) * 60;
        if (mins < 10){
            minsText = "0" + mins;
        }
        else{
            minsText = "" + mins;
        }
        if (secs < 10){
            secsText = "0" + secs;
        }
        else{
            secsText = "" + secs;
        }
        text = minsText + ":" + secsText;
        return text;
    }
}