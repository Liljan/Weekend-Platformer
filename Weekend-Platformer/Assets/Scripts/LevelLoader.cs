using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public string sceneName = "Dev_Gameplay_Scene";
    public Slider slider;
    public Text text;

    public Animator sliderAnimator;

    private void Start()
    {
        LoadLevel(sceneName);
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        bool isLoaded = false;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            if(operation.progress >= 0.9f)
            {
                if(!isLoaded)
                {
                    // set Text
                    sliderAnimator.SetTrigger("Done");
                    isLoaded = true;
                }

                if(Input.GetButtonDown("Enter"))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
