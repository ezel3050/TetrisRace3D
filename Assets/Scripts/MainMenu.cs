using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instnace;
    public UIPanel lostPanel;


    private void Awake()
    {
        instnace = this;
    }


    public void TryAgainButtonClicked()
    {
        SceneManagement.ReloadCurrentLevel();
    }
}
