using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public string sceneName = "Dev_Gameplay_Scene";
    public FillBar fillBar;

    public Text text;
    public Animator textAnimator;

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
        text.text = "Loading...";

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            fillBar.SetFill(progress);

            if (operation.progress >= 0.9f)
            {
                if(!isLoaded)
                {
                    // set Text
                    text.text = "Push <Enter> to start, sucka!";
                    textAnimator.SetTrigger("IsDone");
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
