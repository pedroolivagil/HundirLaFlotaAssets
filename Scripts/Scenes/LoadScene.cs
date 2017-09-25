using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour{
    public Slider SliderLoader;
    public Text TextTitleStatus;
    public Text TextStatus;
    private AsyncOperation _loadScene;
    public static string NavigateScene;
    public bool isMockBar;
    private bool _textChanged;

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
        UpdateTextTitleStatus();
    }

    private void UpdateTextTitleStatus(){
        if (TextTitleStatus != null && SliderLoader != null
            && SliderLoader.value > 60 && !_textChanged){
            TextTitleStatus.text = LocaleManager.Inst().TranslateStr("PRELOAD_SCREEN_GAME2");
            _textChanged = true;
        }
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