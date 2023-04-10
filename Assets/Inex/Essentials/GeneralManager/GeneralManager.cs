using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public static void PauseTheGame()
    {
        Time.timeScale = 0;

    }

    public static void ResumeTheGame()
    {
        Time.timeScale = 1;
    }

}
