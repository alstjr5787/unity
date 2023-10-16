using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    public string nextScene;

    [SerializeField]
    Image progressBar;

    public static void LoadScene(string sceneName)
    {
        //nextScene = sceneName;
        //SceneManager.LoadScene("LoadingScene");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProgress());
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        float duration = 3f; // 로딩 시간을 3초로 설정합니다.

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            float progress = Mathf.Clamp01(timer / duration); // 진행도를 0에서 1 사이로 조절
            progressBar.fillAmount = progress;
            yield return null;
        }

        op.allowSceneActivation = true;
    }
}
