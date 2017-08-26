using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour{
    public Slider SliderLoader;
    public Text TextStatus;
    private AsyncOperation _loadScene;
    public static string NavigateScene;
    public bool isMockBar;

    void Start(){
        SliderLoader.value = 0;
        if (TextStatus){
            TextStatus.text = "0 %";
        }
        if (!isMockBar && NavigateScene != null){
            _loadScene = SceneManager.LoadSceneAsync(NavigateScene, LoadSceneMode.Single);
        }
    }

    void Update(){
        PreLoadScene();
        MockBar();
    }

    private void MockBar(){
        if (isMockBar){
            if (TextStatus){
                TextStatus.text = Mathf.Round(SliderLoader.value) + " %";
            }
        }
    }

    private void PreLoadScene(){
        if (_loadScene != null){
            Debug.Log("Preload scene progress: " + Mathf.Round(_loadScene.progress * 100));
            if (SliderLoader.value <= 100){
                SliderLoader.value = Mathf.Round(_loadScene.progress * 100);
            }
            if (TextStatus){
                TextStatus.text = Mathf.Round(_loadScene.progress * 100) + " %";
            }
        }
    }

    public static void SetNavigateScene(string navigateScene){
        LoadScene.NavigateScene = navigateScene;
    }
}