using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = System.Random;

public class GameManager : MonoBehaviour{
    public static readonly string DIALOG_TAG = "Dialog";
    public int screenWidth = 1920;
    public int screenHeigth = 1080;
    private static int gameMode;
    private static List<Resolution> listResolution;
    private static Config config;
    public static User User{ get; set; }
    public static GameUserData GameData{ get; set; }

// Use this for initialization
    void Start(){
        DontDestroyOnLoad(gameObject);
        config = new Config();
        config.Init();
        listResolution = new List<Resolution>();
        foreach (Resolution res in Screen.resolutions){
            if (!listResolution.Contains(res)){
                listResolution.Add(res);
                if (res.width.Equals(screenWidth) && res.height.Equals(screenHeigth)){
                    SetResolutionGame(res);
                }
            }
        }
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

    public static bool IsNull(object obj){
        return obj == null || obj.Equals("");
    }

    public static bool IsNotNull(object obj){
        return !IsNull(obj);
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
        } else{
            SceneManager.LoadScene(screen, LoadSceneMode.Single);
        }
        Time.timeScale = 1;
    }

    public static void Reload(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
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
                } else{
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

    public static Config GetConfig(){
        return config;
    }

    public static GameObject GetDialogConnection(){
        Component c = GetComponentWithName("DialogConnection");
        if (c != null){
            return c.gameObject;
        }
        return null;
    }

    public static void ShowDialogConnection(){
        GameObject dialog = GetDialogConnection();
        ActiveDialog(dialog);
    }

    public static void HideDialogConnection(){
        GameObject dialog = GetDialogConnection();
        dialog.SetActive(false);
    }

    public static long GetCurrentTimestamp(){
        return (long) (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds * 1000;
    }

    public static DateTime GetDateTimeFromLong(long time){
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return start.AddMilliseconds(time).ToLocalTime();
    }

    public static int RandomBetween(){
        return RandomBetween(1, 50);
    }

    public static int RandomBetween(int end){
        return RandomBetween(1, end);
    }

    public static int RandomBetween(int start, int end){
        Random rnd = new Random();
        return rnd.Next(start, end + 1);
    }

    public static T ParseJsonToObject<T>(string json){
        return JsonUtility.FromJson<T>(json);
    }

    public static string CryptString(string inputString){
        SHA256Managed hash = new SHA256Managed();
        byte[] signatureData = hash.ComputeHash(new UnicodeEncoding().GetBytes(inputString));
        return Convert.ToBase64String(signatureData);
// For PHP read password
// print base64_encode(hash("sha256",mb_convert_encoding("abcdefg","UTF-16LE"),true));
    }

    public static Texture2D ConvertBase64ToTexture2D(string base64){
        Texture2D retorno = null;
        if (IsNotNull(base64)){
            byte[] arr = Convert.FromBase64String(base64);
            Texture2D mapTexture = new Texture2D(1, 1);
            mapTexture.LoadImage(arr);
            mapTexture.Apply();
            retorno = mapTexture;
        }
        return retorno;
    }
}