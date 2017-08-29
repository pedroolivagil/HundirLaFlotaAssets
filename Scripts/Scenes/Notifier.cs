using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Notifier : MonoBehaviour{
    private static Notifier instance;

    public static Notifier GetInstance(){
        init();
        return instance;
    }

    private static void init(){
        if (instance == null){
            instance = new Notifier();
            DontDestroyOnLoad(instance);
        }
    }

    public void SendMessage(string message){
        Canvas canvas = FindObjectOfType<Canvas>();
        Object prefab =
            AssetDatabase.LoadAssetAtPath("Assets/Prefabs/UI/NotifierPanel.prefab", typeof(GameObject));
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