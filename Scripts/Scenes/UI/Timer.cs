using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    public int timeSeconds;
    public bool countDown;

    private Text timer;
    private readonly int MAX_TIME = 5999;
    private int time;
    private float mins;
    private float secs;

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
        timer.text = CalcTimeTextCountDown();
        StartCoroutine(UpdateTimerCountDown());
    }

    private void InitCounter(){
        time = timeSeconds;
        timer.text = CalcTimeText();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer(){
        yield return new WaitForSeconds(1f);
        time++;
        mins = time / 60;
        secs = ((time / 60f) - mins) * 60;
        timer.text = CalcTimeText();
        if (time < MAX_TIME){
            yield return UpdateTimer();
        }
    }

    private IEnumerator UpdateTimerCountDown(){
        yield return new WaitForSeconds(1f);
        time--;
        timer.text = CalcTimeTextCountDown();
        if (time > 0){
            yield return UpdateTimerCountDown();
        }
    }

    private string CalcTimeText(){
        string text;
        string minsText;
        string secsText;
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
        string text;
        string minsText;
        string secsText;
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