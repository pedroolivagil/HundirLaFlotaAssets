using System;
using UnityEngine;

[Serializable]
public class UserInfo{
    public bool flag_active{ get; set; }
    public string firstname{ get; set; }
    public string lastname{ get; set; }
    public string email_security{ get; set; }
    public string phone{ get; set; }
    public string address{ get; set; }
    public int state{ get; set; }
    public string country{ get; set; }
    public string birthday{ get; set; }
    public int gender{ get; set; }

    public override string ToString(){
        return JsonUtility.ToJson(this);
    }
}