using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static readonly string DIALOG_TAG = "Dialog";
    public static readonly int SINGLE_PLAYER = 0;
    public static readonly int MULTI_PLAYER = 1;
    public int screenWidth = 1920;
    public int screenHeigth = 1080;
    private static int gameMode;
    private static List<Resolution> listResolution;

    public class ResponseCode{
        public static readonly int CODE_000 = 0;
        public static readonly int CODE_100 = 100;
        public static readonly int CODE_200 = 200;
        public static readonly int CODE_400 = 400;
        public static readonly int CODE_404 = 404;
    }

    // Use this for initialization
    void Start(){
        DontDestroyOnLoad(gameObject);
        FillIniFile();
        listResolution = new List<Resolution>();
        foreach (Resolution res in Screen.resolutions){
            if (!listResolution.Contains(res)){
                listResolution.Add(res);
                if (res.width.Equals(screenWidth) && res.height.Equals(screenHeigth)){
                    SetResolutionGame(res);
                }
            }
        }
        Debug.Log("INI: " + ReadIni.IniReadValue(ReadIni.Sections.Difficult, ReadIni.Keys.Level));
    }

    public static IEnumerator ExitGame(float time){
        Debug.Log("Exiting...");
        yield return new WaitForSeconds(time);
        Debug.Log("Exited");
        Application.Quit();
    }

    public static void ChangeScreen(string screen, bool preload = false){
        if (preload){
            LoadScene.SetNavigateScene(screen);
            SceneManager.LoadScene(GameScenes.LoadScene, LoadSceneMode.Single);
        }
        else{
            SceneManager.LoadScene(screen, LoadSceneMode.Single);
        }
        Time.timeScale = 1;
    }

    public static void Reload(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public List<Resolution> GetListResolution(){
        return listResolution;
    }

    public void SetResolutionGame(Resolution resolution){
        Debug.Log("Resolution has been changed: " + resolution.width + "x" + resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);
        Screen.fullScreen = true;
    }

    public void ToogleFullScreen(){
        Screen.fullScreen = !Screen.fullScreen;
    }

    public static bool ArrayContains(Object[] array, Object item){
        return new List<Object>(array).Contains(item);
    }

    public static Component GetComponentWithName(string name){
        return GetComponentWithName(name, null);
    }

    public static Component GetComponentWithName(string name, string tag){
        Component retorno = null;
        Canvas c = FindObjectOfType<Canvas>();
        Component[] objs = c.GetComponentsInChildren(typeof(Transform), true);
        foreach (Component gObj in objs){
            if (gObj.name == name){
                if (tag != null){
                    if (gObj.CompareTag(tag)){
                        retorno = gObj;
                    }
                }
                else{
                    retorno = gObj;
                }
            }
        }
        return retorno;
    }

    public static void ActiveDialog(GameObject dialog){
        dialog.SetActive(true);
        MoveInHierarchy(dialog);
    }

    public static void MoveInHierarchy(GameObject gameObject){
        gameObject.transform.SetAsLastSibling();
    }

    private void FillIniFile(){
        ReadIni.IniWriteValue(ReadIni.Sections.Screen, ReadIni.Keys.ScreenWidth, "1920");
        ReadIni.IniWriteValue(ReadIni.Sections.Screen, ReadIni.Keys.ScreenHeight, "1080");
        ReadIni.IniWriteValue(ReadIni.Sections.Locale, ReadIni.Keys.Locale, "English");
        ReadIni.IniWriteValue(ReadIni.Sections.Locale, ReadIni.Keys.Locale, "Spanish");
        ReadIni.IniWriteValue(ReadIni.Sections.Difficult, ReadIni.Keys.Level, "1");
    }
}