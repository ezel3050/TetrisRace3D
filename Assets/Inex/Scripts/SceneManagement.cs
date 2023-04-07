using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static void LoadScene(int sceneIndex)
    {
        

    }

    public static void LoadScene(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;
        ScreenBlackout.instance.BlackFadeIn(() => ao.allowSceneActivation = true);
    }



}
