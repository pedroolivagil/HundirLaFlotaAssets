using System;
using MongoDB.Bson;
using UnityEngine;

[Serializable]
public class User : _Entity{
    public ObjectId _id{ get; set; }
    public long id_user{ get; set; }
    public bool flag_active{ get; set; }
    public bool email_activation{ get; set; } // True si el usuario tiene el email verificado
    public long add_date{ get; set; }
    public string username{ get; set; }
    public string password{ get; set; }
    public string email{ get; set; }

    public int type_user{ get; set; }
    public UserInfo info{ get; set; } // array with user info

    public override string ToString(){
        return JsonUtility.ToJson(this);
    }
}