﻿using UnityEngine;
using UnityEngine.UI;

public class Notifier : MonoBehaviour{
    private static Notifier instance;

    public static Notifier Inst(){
        Init();
        return instance;
    }

    private static void Init(){
        if (instance == null){
            instance = new Notifier();
            DontDestroyOnLoad(instance);
        }
    }

    public void SendMessage(string message){
        Canvas canvas = FindObjectOfType<Canvas>();
        Object prefab = Resources.Load("Prefabs/NotifierPanel", typeof(GameObject));
        GameObject notif = Instantiate(prefab, Vector3.one, Quaternion.identity) as GameObject;
        if (notif != null){
            GameManager.ActiveDialog(notif);
            notif.transform.position = new Vector3(0, -161, 0);
            notif.transform.SetParent(canvas.transform, false);
            Text msgText = notif.GetComponentInChildren<Text>();
            msgText.text = message;
        }
    }
}