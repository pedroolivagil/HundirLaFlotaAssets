using System.Collections;
using UnityEngine;

public class NotifierUI : MonoBehaviour{
    void Start(){
        StartCoroutine(DeleteNotifier());
    }


    private IEnumerator DeleteNotifier(){
        yield return new WaitForSeconds(4f);
        Destroy(gameObject, .5f);
    }
}