﻿using UnityEngine;

public class ExitScene : MonoBehaviour{
    public float timeExit = 3.5f;

    void Start(){
        StartCoroutine(GameManager.ExitGame(timeExit));
    }
}